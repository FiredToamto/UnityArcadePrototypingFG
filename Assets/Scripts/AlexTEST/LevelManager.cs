using System.Collections;
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

    public int coinCount;
    public Text coinText;
    private int _coinBonusLifeCount;
    public int bonusLifeThreshold;
    private bool _respawning;
    
    public int startingLives;
    public int currentLives;
    public Text livesText;
    

    public AudioSource dieSound;
    public AudioSource respawnSound;
    public AudioSource gameOverSound;

    public GameObject gameOverScreen;

    private ResetOnRespawn[] objectsToReset;
    
    
   void Start()
    {
        thePlayer = FindObjectOfType<CharacterController>();
        
        healthCount = maxHealth;
        currentLives = startingLives;
        
        livesText.text = "x" + currentLives;
        coinText.text = "x" + coinCount;

        objectsToReset = FindObjectsOfType<ResetOnRespawn>();
    }

    void Update()
    {
        if (healthCount <= 0 && !_respawning)
        {
            Respawn();
            respawnSound.Play();
            _respawning = true;
        }

        if (_coinBonusLifeCount >= bonusLifeThreshold)
        {
            currentLives += 1;
            livesText.text = "x" + currentLives;
            _coinBonusLifeCount = -bonusLifeThreshold;
            
            _resetCoinCounter();
        }
        
    }

    public void _resetCoinCounter()
    {
        coinCount = 0;
        coinText.text = "x" + coinCount;
        _coinBonusLifeCount = 0;
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

        coinCount = 0;
        coinText.text = "x" + coinCount;
        _coinBonusLifeCount = 0;

        for (int i = 0; i < objectsToReset.Length; i++)
        {
            objectsToReset[i].gameObject.SetActive(true);  
            objectsToReset[i].ResetObject();
        }
        
        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);
        
    }

    public void HurtPlayer(int damageToTake)
    {
        Debug.Log("Hurt!");
        healthCount -= damageToTake;
        UpdateHeartMeter();
    }

    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;
        _coinBonusLifeCount += coinsToAdd;
        coinText.text = "x" + coinCount;
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
