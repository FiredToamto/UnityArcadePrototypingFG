using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketJumpShield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("bullet"))
        {
            bulletMethods = coll.GetComponent<bulletMethods>();
        }
    }
}
