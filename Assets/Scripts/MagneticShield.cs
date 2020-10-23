using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticShield : MonoBehaviour
{
    public SuckedUpBulletManager bulletManager;
    private void OnDisable()
    {
        bulletManager.Shoot();
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Bullet"))
        {
            BulletMethods bulletM = coll.GetComponent<BulletMethods>();
            bulletM.SuckedUp();
            bulletManager._amountOfBullets++;

        }
    }
  
}
