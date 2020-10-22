﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public float waitToRespawn;
    public CharacterController thePlayer;

    public GameObject deathSplotion;

    public Image heart1;
    public Image heart2;
    public Image heart3;

    public Sprite heartFull;
    public Sprite heartHalf;
    public Sprite heartEmpty;

    public int maxHealth;
    public int healthCount;

    private bool _respawning;
    
    public int startingLives;
    public int currentLives;
    public Text livesText;
    

    public AudioSource dieSound;
    public AudioSource respawnSound;
    public AudioSource gameOverSound;

    public GameObject gameOverScreen;
    
    
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<CharacterController>();
        healthCount = maxHealth;
        currentLives = startingLives;
        livesText.text = "x" + currentLives;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthCount <= 0 && !_respawning)
        {
            Respawn();
            respawnSound.Play();
            _respawning = true;
        }
    }

    public void Respawn()
    {
        currentLives -= 1;
        livesText.text = "x" + currentLives;
        
        if (currentLives > 0)
        {
            StartCoroutine("RespawnCo");
        }
        else
            {
                thePlayer.gameObject.SetActive(false);
                gameOverSound.Play();
                gameOverScreen.SetActive(true);
            }
        
    }

    public IEnumerator RespawnCo()
    {
        thePlayer.gameObject.SetActive(false);
        
        Instantiate(deathSplotion, thePlayer.transform.position, thePlayer.transform.rotation);
        
        
        yield return new WaitForSeconds(waitToRespawn);

        healthCount = maxHealth;
        _respawning = false;
        UpdateHeartMeter();

        
        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);
        
    }

    public void HurtPlayer(int damageToTake)
    {
        Debug.Log("Hurt!");
        healthCount -= damageToTake;
        UpdateHeartMeter();
    }

    public void UpdateHeartMeter()
    {
        switch (healthCount)
        {
            case 6: 
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                return;
            
            case 5: 
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;
                return;
            
            case 4: 
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                return;
            
            case 3: 
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                heart3.sprite = heartEmpty;
                return;
            
            case 2: 
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;
            
            case 1: 
                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;
            
            case 0: 
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;
                
                default: 
                    heart1.sprite = heartEmpty;
                    heart2.sprite = heartEmpty;
                    heart3.sprite = heartEmpty;
                    return;
        }
        
        
    }
}
