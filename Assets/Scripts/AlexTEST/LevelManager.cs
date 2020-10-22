using System.Collections;
using System.Collections.Generic;
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
    
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCo");
    }

    public IEnumerator RespawnCo()
    {
        thePlayer.gameObject.SetActive(false);
        Instantiate(deathSplotion, thePlayer.transform.position, thePlayer.transform.rotation);
        
        
        yield return new WaitForSeconds(waitToRespawn);
        
        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);
        
    }
    
}
