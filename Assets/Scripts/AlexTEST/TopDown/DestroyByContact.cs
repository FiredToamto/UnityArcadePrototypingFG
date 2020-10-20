using UnityEngine;

namespace TopDown
{
    public class DestroyByContact : MonoBehaviour
    {
        public GameObject explosion;
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name);

            if (other.tag == "Boundary")
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
