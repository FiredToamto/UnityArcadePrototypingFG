using UnityEngine;

namespace AlexTEST.TopDown
{
    public class DestroyOnContact : MonoBehaviour
    {
        public GameObject explosion;
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name);

            if (other.CompareTag("Boundary"))
            {
                return;
            }

            Instantiate(explosion, transform.position, transform.rotation);
            // destroy laser shot
            Destroy(other.gameObject);
            //destroy gameObject with this script attached
            Destroy(gameObject);
        }
        
    }
}
