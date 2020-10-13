using UnityEngine;

public class DeflectBullet : MonoBehaviour
{
    public int shieldType = 1;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        BulletMovement bullet = coll.GetComponent<BulletMovement>();
        Rigidbody2D rbBullet = coll.GetComponent<Rigidbody2D>();
        if (bullet != null)
        {
            rbBullet.velocity =  new Vector2(0, 0);
            bullet.Interact(shieldType);
        }
    }
}
