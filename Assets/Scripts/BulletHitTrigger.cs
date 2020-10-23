using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletHitTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            if (GetComponent<BulletMoveBackToOwner>().deflected)
            {
                coll.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
        if (coll.gameObject.CompareTag("Player"))
        {
            GetComponent<BulletMethods>().BulletExplode();
        }
        else
        {
            GetComponent<BulletMethods>().BulletExplode();

        }

    }

}
