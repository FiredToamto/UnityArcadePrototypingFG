using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private LevelManager _theLevelManager;

    public int coinValue;
    public AudioSource pickUpSound;
    
    
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
            Debug.Log("Trigger");
            pickUpSound.Play();
            _theLevelManager.AddCoins(coinValue);
            Destroy(gameObject);

        }
    }
}
