using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour, IInteraction
{
    public Transform bulletOwner;
    public float bulletSpeed = 10f;
    public int bulletType = 1;
    public bool deflected = false;

    private Transform _tr;
    private Rigidbody2D _rB;
    void Awake()
    {
        deflected = false;
        _tr = GetComponent<Transform>();
        _rB = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        _placeHolderMethod();
    }
    public void Interact(int colorType)
    {
        if (colorType == bulletType)
        {
            _rB.velocity = new Vector2(0, 0);
            deflected = true;
        }
    }
    private void _placeHolderMethod() 
    {
        if (deflected)
        {
            _tr.position = Vector3.MoveTowards(_tr.position, bulletOwner.position, Time.deltaTime * bulletSpeed);
        }
    }
}