using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHoming : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootIntervall = 10f;
    public float bulletSpeed = 10f;
    //public int enemyType = 1;
    public SpriteRenderer sR;

    private Transform _tr;
    private Transform playerPos;
    private IEnumerator coroutine;
    private void Awake()
    {
        _tr = GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            coroutine = ShootTimer(shootIntervall);
            playerPos = coll.GetComponent<Transform>();
            Shoot();
            StartCoroutine(coroutine);
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            StopCoroutine(coroutine);
        }
    }
    private IEnumerator ShootTimer(float intervall)
    {
        while (true)
        {
            yield return new WaitForSeconds(intervall);
            Shoot();
        }
    }
    private void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
        newBullet.GetComponent<Transform>().LookAt(playerPos);
        newBullet.GetComponent<Transform>().rotation = new Quaternion(newBullet.GetComponent<Transform>().rotation.x, newBullet.GetComponent<Transform>().rotation.y, newBullet.GetComponent<Transform>().rotation.z - 90f, 0);
        newBullet.GetComponent<SpriteRenderer>().color = sR.color;
        //newBullet.GetComponent<BulletMoveBackToOwner>().bulletType = enemyType;
        newBullet.GetComponent<BulletMoveBackToOwner>().bulletOwner = _tr;
        newBullet.GetComponent<Rigidbody2D>().velocity = (playerPos.position - newBullet.transform.position).normalized * bulletSpeed;
    }
}
