using UnityEngine;

namespace TopDown
{
    public class MouseAiming : MonoBehaviour
    {
        public Rigidbody2D rb;
        public Camera cam;

        private Vector2 _mousePosition;
    
    
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            //Calculate where mouse is from pixels to world pos.
            _mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
          
        
        }

        void FixedUpdate()
        {
            //MOUSE AIMING
            //calculate mouse direction from player to mouse.
            Vector2 lookDir = _mousePosition - rb.position;
            //Return y,x angle from mouse direction. convert radians to degrees.
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            //Apply to player
            rb.rotation = angle;
        
        }
    }
}
