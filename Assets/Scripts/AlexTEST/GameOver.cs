using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public string levelSelect;
    public string mainMenu;

    private LevelManager _theLevelManager;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _theLevelManager = FindObjectOfType<LevelManager>();
    }

    public void Restart()
    {
        PlayerPrefs.SetInt("PlayerLives", _theLevelManager.startingLives);
        //PlayerPrefs.SetInt("CoinCount", 0);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void LevelSelect()
    {
        PlayerPrefs.SetInt("PlayerLives", _theLevelManager.startingLives);
       
        SceneManager.LoadScene(levelSelect);
        
    }
    
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
    
    
    
}
