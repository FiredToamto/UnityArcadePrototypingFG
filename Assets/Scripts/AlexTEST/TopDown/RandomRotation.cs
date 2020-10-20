using UnityEngine;

namespace AlexTEST.TopDown
{
    public class RandomRotation : MonoBehaviour
    {

        public float tumble;
        
        void Start()
        {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        }

    
    }
}
