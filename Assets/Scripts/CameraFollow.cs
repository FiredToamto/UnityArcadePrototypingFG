using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followObject;
    public Vector2 followOffset;
    public float speed = 3f;
    private Vector2 threshold;
    private Rigidbody2D rb;

    void Start()
    {
        //Sets amount of distance player can move within boundary box before camera pans (follow offset)
        threshold = calculateThreshold();

        //Sets camera panning speed equal to the character's Rigidbody speed
        rb = followObject.GetComponent<Rigidbody2D>();

        
    }

    void FixedUpdate()
    {
        // Tracks player's distance from the X-axis & Y-axis respectively
        Vector2 follow = followObject.transform.position;
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        //Camera will stick to where its placed
        Vector3 newPosition = transform.position;

        //Camera will move in the direction of the followed object's X-axis and Y-axis respectively
        if(Mathf.Abs(xDifference) >= threshold.x){
            newPosition.x = follow.x;
        }
        if(Mathf.Abs(yDifference) >= threshold.y){
            newPosition.y = follow.y;
        }

        // Prevents character from outspeeding the camera
        float moveSpeed = rb.velocity.magnitude > speed ? rb.velocity.magnitude : speed;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);

    }
        //Sets the boundary box for the camera (outputs the threshold boundary box through a vector3 value)
        private Vector3 calculateThreshold(){
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        t.x -= followOffset.x;
        t.y -= followOffset.y;
        return t;
    }
        // Draws adjustable visual representation of boundary box threshold in editor
    private void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        Vector2 border = calculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));

    }
}
