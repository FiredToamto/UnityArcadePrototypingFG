using UnityEngine;

namespace AlexTEST.TopDown
{
    public class Mover : MonoBehaviour
    {
        public float speed;
        void Start()
        {    //How fast object with script will move
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }

   
    }
}
