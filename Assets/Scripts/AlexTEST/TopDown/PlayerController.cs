using System;
using UnityEngine;

namespace AlexTEST.TopDown
{
    [Serializable]
    public class Boundary
    {  //Serialized float for movement boundaries 
        public float xMin, xMax, yMin, yMax;
    }

    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public Rigidbody2D rb;
        public Boundary boundary;
        public float tilt;
        public Camera cam;
        public Transform firePoint;
        public GameObject bulletPrefab;
        public float bulletForce;

        private Vector2 _movement;
        private Vector2 _mousePosition;
        
        void Update()
        {
            //input from Input Manager
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");
            
            //Calculate where mouse is from pixels to world pos.
            _mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            
            //Create a clamped boundary where the player can or cannot move
            rb.position = new Vector3
                
            (
                Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
                Mathf.Clamp (rb.position.y, boundary.yMin, boundary.yMax), 
                0.0f
                
            );
            
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
            
        }

        void FixedUpdate()
        { 
            //Rigidbody movement calculation
            rb.MovePosition(rb.position + _movement * moveSpeed * Time.fixedDeltaTime);
           
            //MOUSE AIMING
            //calculate mouse direction from player to mouse.
            Vector2 lookDir = _mousePosition - rb.position;
            //Return y,x angle from mouse direction. convert radians to degrees.
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            //Apply to player
            rb.rotation = angle;
            

            
           
           //test of tilt....
            //rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

           
            /*
             
             Testing tilt stuff
             
             
             //Move the controller in that direction
             controller.MovePosition (transform.position + (inputVec) * Time.deltaTime);
  
             //Determines the level of tilt based on user input
             if (Mathf.Abs (vertical) > 0 && Mathf.Abs (horizontal) > 0) 
             {
                 tiltAngle = 1.5f;
             } 
             else 
             {
                 tiltAngle = 3f;
             }
  
             //Calculates the tilt based on user input
             
             Quaternion target = Quaternion.Euler ((Mathf.Abs(vertical) + Mathf.Abs(horizontal)) * tiltAngle, 0, 0);
  
             if (inputVec != Vector3.zero) 
             {
                 //Smoothing rotates the character and assigns the new rotation to CharacterRotation
                 characterRotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (inputVec, Vector3.up), Time.deltaTime * smooth);
                 transform.rotation = characterRotation * target;
             }
            */
        }
        
        void Shoot()
        {    // instantiate spawn bullet, get rigidbody of bullet, Add force from firePoint vector + force
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}