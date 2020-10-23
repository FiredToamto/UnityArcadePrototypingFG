using UnityEngine;

public class DeflectBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Bullet"))
        {
            BulletMethods bulletM = coll.GetComponent<BulletMethods>();
            bulletM.DisableVelocity();
            bulletM.Deflected();
        }
    }
}
