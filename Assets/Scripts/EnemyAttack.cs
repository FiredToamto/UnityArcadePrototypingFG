using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject bulletPreFab;
    public float shootIntervall = 10f;
    public float bulletSpeed = 10f;

    private Transform _tr;
    // Start is called before the first frame update
    private void Awake()
    {
        _tr = GetComponent<Transform>();
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
            GameObject newBullet = Instantiate(bulletPreFab, gameObject.transform.position, gameObject.transform.rotation);
            newBullet.GetComponent<BulletMovement>().bulletOwner = _tr;
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
        }
    }

}
