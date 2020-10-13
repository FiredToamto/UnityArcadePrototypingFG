using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShieldControll : MonoBehaviour
{
    public GameObject shieldOne;
    public KeyCode shieldButton;

    private bool _state = false;

    private void Update()
    {
        shieldInput();
    }

    private void shieldInput()
    {
        if (Input.GetKeyDown(shieldButton))
        {
            _state = !_state;
            shieldToggle();
        }
        if (Input.GetKeyUp(shieldButton))
        {
            _state = !_state;
            shieldToggle();
        }
    }

    private void shieldToggle()
    {
        shieldOne.SetActive(_state);
    }
}
