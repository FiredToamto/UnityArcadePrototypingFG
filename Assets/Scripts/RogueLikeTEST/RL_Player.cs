using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL_Player : RL_MovingObject
{
    public int wallDamage = 1;
    public int pontsPerFood = 10;
    public int pointsPerSoda = 20;
    public float restartLevelDelay = 1f;

    private Animator _animator;
    private int _food;


    // Start is called before the first frame update
    protected override void Start()
    {
        _animator = GetComponent<Animator>();

        _food = RL_GameManager.instance.playerFoodPoints;

        base.Start();
    }

    private void OnDisable()
    {
        RL_GameManager.instance.playerFoodPoints = _food;
    }

    // Update is called once per frame
    void Update()
    {
        if (!RL_GameManager.instance.playerTurn) return;

        int horizontal = 0;
        int Vertical = 0;

        horizontal = (int)Input.GetAxisRaw("Horizontal");
        Vertical = (int)Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
            Vertical = 0;

        if (horizontal != 0 || Vertical != 0)
            AttemptMove <RL_Wall>(horizontal, Vertical);
    }

    protected override void AttemptMove <T> (int xDir, int yDir)
    {
        _food--;

        base.AttemptMove<T>(xDir, yDir);

        RaycastHit2D hit;

        CheckIfGameOver();

        RL_GameManager.instance.playerTurn = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Exit")
        {
            Invoke("Restart", restartLevelDelay);
            enabled = false;
        }
        else if (other.tag == "Food")
        {
            _food += pontsPerFood;
            other.gameObject.SetActive(false);

        }
        else if (other.tag == "soda")
        {
            _food += pointsPerSoda;
            other.gameObject.SetActive(false);
        }
    }

    protected override void onCantMove<T>(T component)
    {
        RL_Wall hitWall = component as RL_Wall;
        hitWall.DamageWall(wallDamage);
        //Animator.SetTrigger("playerChop");
              
    }

    private void Restart()
    {
        Application.LoadLevel(Application.loadedLevel); 
    }

    /*public void LoseFood (int loss)
    {

        Animator.SetTrigger("playerHit");
        _food -= loss;
        CheckIfGameOver();

    }
    */

    private void CheckIfGameOver()
    {

        if (_food <= 0)
            RL_GameManager.instance.GameOver ();

    }
}
