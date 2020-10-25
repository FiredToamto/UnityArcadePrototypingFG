using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletHitTriggerPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            coll.gameObject.SetActive(false);
            gameObject.SetActive(false);
            
        }
        if (coll.gameObject.CompareTag("Shield"))
        {
            return;
        }
        if (coll.gameObject.CompareTag("Untagged"))
        {
            GetComponent<BulletMethods>().BulletExplode();
        }
    }

}
