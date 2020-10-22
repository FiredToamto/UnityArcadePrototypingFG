using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;
    public AudioSource damageSound;
    
    private LevelManager _theLevelManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _theLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {    
            damageSound.Play();
            _theLevelManager.HurtPlayer(damageToGive);

        }
    }
}


