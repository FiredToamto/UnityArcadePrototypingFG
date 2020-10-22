using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShieldControll : MonoBehaviour
{
    public GameObject shield;
    public KeyCode shieldButton;

    private bool _state = false;

    private void Update()
    {
        ShieldInput();
    }

    private void ShieldInput()
    {
        if (Input.GetKeyDown(shieldButton))
        {
            _state = !_state;
            ShieldToggle();
        }
        if (Input.GetKeyUp(shieldButton))
        {
            _state = !_state;
            ShieldToggle();
        }
    }

    private void ShieldToggle()
    {
        shield.SetActive(_state);
    }
}
