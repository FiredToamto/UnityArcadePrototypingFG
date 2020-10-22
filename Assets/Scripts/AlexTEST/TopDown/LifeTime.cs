using UnityEngine;

namespace AlexTEST.TopDown
{
    public class LifeTime : MonoBehaviour
    {
    
        public float TimeToLive = 5f;
   
    
        private void Start()
        {
            Destroy(gameObject, TimeToLive);
        }
    }
}
