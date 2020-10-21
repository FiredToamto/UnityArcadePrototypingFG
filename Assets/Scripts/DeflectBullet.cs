using UnityEngine;

public class DeflectBullet : MonoBehaviour
{
    public int shieldType = 1;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        IInteraction bullet = coll.GetComponent<BulletMovement>();
        Rigidbody2D rbBullet = coll.GetComponent<Rigidbody2D>();
        if (bullet != null)
        {
            bullet.Interact(shieldType);
        }
    }
}
