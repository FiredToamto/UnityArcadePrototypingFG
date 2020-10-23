using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{

    public string levelSelect;
    public string mainMenu;

    public GameObject thePauseScreen;
    
    private LevelManager _theLevelManager;

    private CharacterController _thePlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        _theLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            if(Time.timeScale == 0f)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    
    public void PauseGame()
    {
        Time.timeScale = 0;

        thePauseScreen.SetActive(true);
        _thePlayer.canMove = (false);
        //theLevelManager.levelMusic.Pause();
    }
   
    public void ResumeGame()
    {
        Time.timeScale = 1;
        
        thePauseScreen.SetActive(false);
        
        _thePlayer.canMove = (true);
        //_theLevelManager.levelMusic.Play();
    }
    
    public void LevelSelect()
    {
        PlayerPrefs.SetInt("PlayerLives", _theLevelManager.currentLives);
       // PlayerPrefs.SetInt("CoinCount", _theLevelManager.coinCount);

       Time.timeScale = 1f;
       
       SceneManager.LoadScene(levelSelect);
    }
    
    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);
    }
    
    
    
}

