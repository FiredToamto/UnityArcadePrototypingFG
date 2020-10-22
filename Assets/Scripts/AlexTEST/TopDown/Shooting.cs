using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexTEST.TopDown
{
    public class Shooting : MonoBehaviour
    {
        public Transform firePoint;
        public GameObject bulletPrefab;

        public float bulletForce;
        
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }

        void Shoot()
        {    // instantiate spawn bullet, get rigidbody of bullet, Add force from firePoint vector + force
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        
        
        
        
    }
}
