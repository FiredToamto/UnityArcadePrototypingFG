using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class GhostTrail : MonoBehaviour
{
    public float ghostDelay;
    private float ghostDelaySeconds;
    public GameObject ghost;
    public bool makeGhost = true;

    void Start()
    {
        ghostDelaySeconds = ghostDelay;

    }

    void Update()
    {   
            // Checks if player is moving to generate trail


        
        if (ghostDelaySeconds > 0)
        {   // Time since last frame
            ghostDelaySeconds -= Time.deltaTime;
        }
        else
        {
            //Generate a ghost
            GameObject currentGhost = Instantiate(ghost, transform.position, transform.rotation);

            //Sets the ghost trail to mimic current sprite frame
            currentGhost.transform.localRotation = this.transform.localRotation;

           ghostDelaySeconds = ghostDelay;

            //Destroys ghost after set delay
            Destroy(currentGhost, 1f);
        }
    }
}