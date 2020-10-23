using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShieldControll : MonoBehaviour
{
    public GameObject shield;
    public KeyCode shieldButton;

    private void Awake()
    {
        shield.SetActive(false);
    }

    private void Update()
    {
        ShieldInput();
    }

    private void ShieldInput()
    {
        if (Input.GetKeyDown(shieldButton))
        {
            ShieldToggle(true);
        }
        if (Input.GetKeyUp(shieldButton))
        {
            ShieldToggle(false);
        }
    }

    private void ShieldToggle(bool state)
    {
        shield.SetActive(state);
    }
}
