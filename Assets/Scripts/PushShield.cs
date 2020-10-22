﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushShield : MonoBehaviour
{
    public float pushForce = 10f;
    public Rigidbody2D playerBody;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Bullet"))
        {
            Vector3 bulletPos = coll.GetComponent<Transform>().position;
            BulletMethods bulletM = coll.GetComponent<BulletMethods>();
            PushPlayerInBulletDirection(bulletPos);
        }
    }

    private void PushPlayerInBulletDirection(Vector3 bulletDirection)
    {
        playerBody.AddForce((transform.position - bulletDirection).normalized * pushForce);
    }
}
