using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnRespawn : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Vector3 startLocalScale;

    private Rigidbody2D _myRigibody;
    
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        startLocalScale = transform.localScale;

        if (GetComponent<Rigidbody2D>() != null)
        {
            _myRigibody = GetComponent<Rigidbody2D>();

        } 
    }

    
    void Update()
    {
        
    }

    public void ResetObject()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
        transform.localScale = startLocalScale;

        if (_myRigibody != null)
        {
            _myRigibody.velocity = Vector3.zero;
        }

    }
}
