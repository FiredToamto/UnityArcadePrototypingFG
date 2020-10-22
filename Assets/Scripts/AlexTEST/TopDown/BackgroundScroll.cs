using UnityEngine;

namespace AlexTEST.TopDown
{
    public class BackgroundScroll : MonoBehaviour
    {
        private Material _material;
        private Vector2 _offset;

        public float xVelocity, yVelocity;
        
        
        private void Awake()
        {
            //Acces to material on game object
            _material = GetComponent<Renderer>().material;
        }

        void Start()
        {    
            // create new offset based on velocity
            //_offset = new Vector2(xVelocity, yVelocity);
        }
        
        void Update()
        {
            // create new offset based on velocity
            // access to offset
            _offset = new Vector2(xVelocity, yVelocity);
            _material.mainTextureOffset += _offset * Time.deltaTime;


        }
    }
}
