﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMethods : MonoBehaviour
{
    public void BulletExplode()
    {
        gameObject.SetActive(false);
        //partilce effects
        //kills/destroys enemy or player when triggered
        //kills/destroys itself
    }
    public void Deflected()
    {
        //deflect bullet back to enemy
    }
    public void DisableVelocity()
    {
        GetComponent<Rigidbody2D>().velocity.Set(0f, 0f);
    }
    public void SuckedUp()
    {
        gameObject.SetActive(false);
        //particle effect
        //sound effect
        //animation
    }
    public void DisableHitDetection()
    {

    }
}
