using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveBackToOwner : MonoBehaviour
{
    public Transform bulletOwner;
    public float bulletSpeed = 10f;
    public int bulletType = 1;
    public bool deflected = false;

    private Transform _tr;
    private Rigidbody2D _rB;
    void Awake()
    {
        deflected = false;
        _tr = GetComponent<Transform>();
        _rB = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        MoveBack();
    }
    private void MoveBack()
    {
        if (deflected)
        {
            _tr.position = Vector3.MoveTowards(_tr.position, bulletOwner.position, Time.deltaTime * bulletSpeed);
        }
    }
}
