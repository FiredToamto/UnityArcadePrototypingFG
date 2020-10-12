using UnityEngine;
using System.Collections;


public class BulletMovement : MonoBehaviour
{
    public Transform bulletOwner;
    public float bulletSpeed = 10f;

    private Transform _tr;
    void Awake()
    {
        _tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _placeHolderMethod();
    }

    private void _placeHolderMethod() 
    {
        if (Input.anyKey)
        {
            _tr.position = Vector3.MoveTowards(_tr.position, bulletOwner.position, Time.deltaTime * bulletSpeed);
        }
    }
}
