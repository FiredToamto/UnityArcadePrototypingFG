using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHoming : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootIntervall = 10f;
    public float bulletSpeed = 10f;
    public int enemyType = 1;

    private Transform _tr;
    private SpriteRenderer _sR;
    // Start is called before the first frame update
    private void Awake()
    {
        _tr = GetComponent<Transform>();
        _sR = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        StartCoroutine(Shoot(shootIntervall));
    }

    private IEnumerator Shoot(float intervall)
    {
        while (true)
        {
            yield return new WaitForSeconds(intervall);
            GameObject newBullet = Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
            newBullet.GetComponent<SpriteRenderer>().color = _sR.color;
            newBullet.GetComponent<BulletMovement>().bulletType = enemyType;
            newBullet.GetComponent<BulletMovement>().bulletOwner = _tr;
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
        }
    }

}
