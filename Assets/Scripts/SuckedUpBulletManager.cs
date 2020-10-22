using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckedUpBulletManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int _amountOfBullets = 0;

    private float _shootIntervall = 0.3f;
    private IEnumerator coroutine;

    public void Shoot()
    {
        coroutine = ShootTimer(_shootIntervall);
        StartCoroutine(coroutine);
    }

    private void ReleaseAllBullets()
    {
        if (_amountOfBullets == 0)
        {
            return;
        }
        for (int i = 0; i < _amountOfBullets; i++)
        {
            GameObject newBullet = Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * 10f;
        }
        _amountOfBullets = 0;
    }
    private void ShootBullet()
    {
        if (_amountOfBullets == 0)
        {
            StopCoroutine(coroutine);
            return;
        }
        GameObject newBullet = Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * 10f;
        _amountOfBullets--;
    }
    private IEnumerator ShootTimer(float intervall)
    {
        while (_amountOfBullets > 0)
        {
            yield return new WaitForSeconds(intervall);
            ShootBullet();
        }
    }
}
