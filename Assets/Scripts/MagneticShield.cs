using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticShield : MonoBehaviour
{
    private int _amountOfBullets = 0;

    private void OnDisable()
    {

    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Bullet"))
        {
            _amountOfBullets++;
        }
    }
}
