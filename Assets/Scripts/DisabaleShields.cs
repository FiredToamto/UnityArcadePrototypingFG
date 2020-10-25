using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabaleShields : MonoBehaviour
{
    public GameObject shieldOne;
    public GameObject shieldTwo;
    public GameObject shieldThree;
    private void OnEnable()
    {
        shieldOne.SetActive(false);
        shieldTwo.SetActive(false);
        shieldThree.SetActive(false);
    }
}
