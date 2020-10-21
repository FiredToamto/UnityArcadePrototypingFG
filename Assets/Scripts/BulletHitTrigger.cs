using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletHitTrigger : MonoBehaviour
{
    private GameObject bullet;
    private void Awake()
    {
        bullet = gameObject;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Debug.Log("killed or hurt player");
            coll.gameObject.GetComponent<Respawner>().Respawn();
            bullet.SetActive(false);

        }
        if (coll.gameObject.CompareTag("Enemy"))
        {
            if (bullet.GetComponent<BulletMovement>().deflected)
            {
                Debug.Log("killed or hurt enemy");
                coll.gameObject.SetActive(false);
                bullet.SetActive(false);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
    }
}
