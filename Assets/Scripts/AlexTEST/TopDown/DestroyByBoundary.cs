using UnityEngine;

namespace AlexTEST.TopDown
{
    public class DestroyByBoundary : MonoBehaviour
    {
        void OnTriggerExit(Collider other)
        {
            Debug.Log(other.name);
            Destroy(other.gameObject);
        }
    }
    
    
}
