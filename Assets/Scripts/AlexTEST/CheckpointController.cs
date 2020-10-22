using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    public Sprite flagClosed;
    public Sprite flagOpen;

    private SpriteRenderer theSpriteRenderer;

    public bool checkpointActive;

    void Start()
    {
        theSpriteRenderer = GetComponent<SpriteRenderer>();
    }
        
    void Update()
    {
        
    }
    // Has the player passed through check point. If 'Player' change sprite. 
    // show if active or not.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            theSpriteRenderer.sprite = flagOpen;
            checkpointActive = true;
        }
    }

}