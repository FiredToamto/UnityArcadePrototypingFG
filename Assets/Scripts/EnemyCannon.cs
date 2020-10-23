using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootIntervall = 10f;
    public float bulletSpeed = 10f;
    public Vector3 bulletSize;
    public SpriteRenderer sR;

    private Transform _tr;
    private Transform playerPos;
    private IEnumerator coroutine;
    private void Awake()
    {
        _tr = GetComponent<Transform>();
    }
    private void Start()
    {
        coroutine = ShootTimer(shootIntervall);
        Shoot();
        StartCoroutine(coroutine);
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
        newBullet.GetComponent<Transform>().localScale = bulletSize;
        newBullet.GetComponent<SpriteRenderer>().color = sR.color;
        newBullet.GetComponent<BulletMoveBackToOwner>().bulletOwner = _tr;
        newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
    }
}
