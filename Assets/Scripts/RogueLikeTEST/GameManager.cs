using UnityEngine;

namespace RogueLikeTEST
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager
            instance = null;

        private BoardManager _boardScript;
        private int level = 3;
    
        void Start()
        {
            if (instance == null)
                instance = this;

            else if (instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
            _boardScript = GetComponent<BoardManager>();

            InitGame();
        }

        void InitGame()
        {
            _boardScript.SetupScene(level);

        }
    
        void Update()
        {

        }

    }
}    