using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMethods : MonoBehaviour
{
    public void bulletExplode()
    {
        //partilce effects
        //kills/destroys enemy or player when triggered
        //kills/destroys itself
    }
    public void deflect()
    {
        //deflect bullet back to enemy
    }
    public void disableVelocity()
    {
        GetComponent<Rigidbody2D>().velocity.Set(0f, 0f);
    }
    public void disableHitDetection()
    {

    }
}
