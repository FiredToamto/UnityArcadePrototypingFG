using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL_GameManager : MonoBehaviour
{
    public float turnDelay =1f;
    public static RL_GameManager instance = null;
    public RL_BoardManager boardScript;
    public int playerFoodPoints = 100;
    [HideInInspector] public bool playerTurn = true;

    private int _level = 3;
    private List<Enemy> _enemies;
    private bool _enemiesMoving;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        _enemies = new List<Enemy>(); 
        boardScript = GetComponent<RL_BoardManager>();
        InitGame();
    }

    void InitGame()
    {
        _enemies.Clear();
        boardScript.SetupScene(_level);
     
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTurn || _enemiesMoving)
            return;

        StartCoroutine(MoveEnemies());
    }

    public void AddEnemyToList(RL_Enemy script)
    {
        _enemies.Add(script);

    }

    IEnumerator MoveEnemies()
    {
        _enemiesMoving = true;
        yield return new WaitForSeconds(turnDelay);
        if (_enemies.Count == 0)
        {
            yield return new WaitForSeconds(turnDelay);

        }

        for (int i = 0; i < _enemies.Count; i++)
        {
            _enemies[i].MoveEnemy();
            yield return new WaitForSeconds(_enemies[i].moveTime);

        }

        playerTurn = true;
        _enemiesMoving = false;

    }


}
