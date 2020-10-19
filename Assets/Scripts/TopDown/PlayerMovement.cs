using System;
using UnityEngine;

namespace TopDown
{
    [Serializable]
    public class Boundary
    {
        public float xMin, xMax, yMin, yMax;
    }

    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public Rigidbody2D rb;
        public Boundary boundary;
        public float tilt;

        private Vector2 _movement;
        
        void Update()
        {
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");
            
            rb.position = new Vector3
                
            (
                Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
                Mathf.Clamp (rb.position.y, boundary.yMin, boundary.yMax), 
                0.0f
                
            );
            
        }

        void FixedUpdate()
        {
            rb.MovePosition(rb.position + _movement * moveSpeed * Time.fixedDeltaTime);
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
    }
}