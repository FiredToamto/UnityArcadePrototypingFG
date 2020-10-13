using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL_Loader : MonoBehaviour
{
    public GameObject gameManager;

 
    void Start()
    {
        if (RL_GameManager.instance == null)
            Instantiate(gameManager);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
