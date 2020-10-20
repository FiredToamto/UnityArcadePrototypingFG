using UnityEngine;

namespace TopDown
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
