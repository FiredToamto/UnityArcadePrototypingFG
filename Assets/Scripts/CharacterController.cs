using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Security.Cryptography;
using UnityEngine;

public class CharacterController : MonoBehaviour
{


    [Header("Horizontal Movement")]
    public float moveSpeed = 6f;
    public Vector2 direction;
    private bool facingRight = true;

    [Header("Vertical Movement")]
    public float jumpSpeed = 15f;
    public float jumpDelay = 0.25f;
    private float jumpTimer;

    [Header("Components")]
    public Transform character;
    public Rigidbody2D rb;
    public Animator animator;
    public LayerMask groundLayer;

    [Header("Physics")]
    public float maxSpeed = 7f;
    public float linearDrag = 4f;
    public float gravity = 1;
    public float fallMultiplier = 5f;

    [Header("Collision")]
    public bool onGround = false;
    public float groundLength = 0.6f;
    public Vector3 colliderOffset;

    [Header("Ghost Trail")]
    public GhostTrail ghost;

    [Header("ParticleSystem")] 
    public ParticleSystem PS;


    void Update() 
    {
        onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);

        //Jumps when the assigned button is pressed
        if(Input.GetButtonDown("Jump")){
           //Declaring the jump function
            jumpTimer = Time.time + jumpDelay;

        }


        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void FixedUpdate()
    {   //Checks if the player is grounded to allow jumping and their jump delay
        moveCharacter(direction.x);
        if(jumpTimer > Time.time && onGround){
           Jump();
           Debug.Log("Jump");
           ParticleSystem PS01 = Instantiate(PS, transform);
           PS01.Play();
           
        }

        animator.SetBool("IsGrounded", false);
        animator.SetBool("Jumping", true);

        modifyPhysics();
    }
    void moveCharacter(float Horizontal)
    {

        animator.SetFloat("Horizontal", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("Vertical", Mathf.Abs(rb.velocity.y));
        rb.AddForce(Vector2.right * Horizontal * moveSpeed);

        if ((Horizontal > 0 && !facingRight) || (Horizontal < 0 && facingRight))
        {
            Flip();
        }
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        jumpTimer = 0; //Sets jump delay
    }

    void modifyPhysics(){
        bool changingDirections = (direction.x > 0 && rb.velocity.x < 0) || (direction.x < 0 && rb.velocity.x > 0);

        if (onGround)
        {
            animator.SetBool("IsGrounded", true);
            animator.SetBool("Jumping", false);

            if (Mathf.Abs(direction.x) < 0.4f){
                 rb.drag = linearDrag;
              }else{
                 rb.drag = 0f;
              }
             rb.gravityScale = 0;

            }else{
                rb.gravityScale = gravity; //If grounded, gravity is 0. Gravity is triggered mid-air.
                rb.drag = linearDrag * 0.15f;
                if (rb.velocity.y < 0){
                rb.gravityScale = gravity * fallMultiplier;
                }else if(rb.velocity.y > 0 && !Input.GetButton("Jump")){
                rb.gravityScale = gravity * (fallMultiplier / 2); //Limits jump if not held down.
            }
          }
        }
    
    void Flip()
    {
        facingRight = !facingRight;
        character.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }
    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        //Sets editor linetrace for ground collision; their collider offset should be adjusted in the inspector variable to be just inside of the CharacterController's boundary box on the X axis (not Y axis)
        Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);
    }
}
