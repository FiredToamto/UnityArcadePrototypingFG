using UnityEngine;

namespace RogueLikeTEST
{
    public class Loader : MonoBehaviour
    {

        public GameObject gameManager;
        // public GameObject soundManager;
    
    
        void Start()
        {
            if (GameManager.instance == null)
                Instantiate(gameManager);
        
            /*if (soundManager.instance == null)
            (Instantiate(soundManager))
            */
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
