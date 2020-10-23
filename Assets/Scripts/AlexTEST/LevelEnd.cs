using System.Collections;
using System.Collections.Generic;
using AlexTEST.TopDown;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public string levelToLoad;
    public string levelToUnlock;
    
    private CharacterController _thePlayer;
    //Should be camera controller??? 
    private FollowTarget _theCamera;
    private LevelManager _theLevelManager;

    public float waitToMove;
    public float waitToLoad;

    private bool _movePlayer;

    public ParticleSystem finishLineParticle;
    public AudioSource finishAudio;

    
        
    void Start()
    {
        
        
        _thePlayer = FindObjectOfType<CharacterController>();
        _theCamera = FindObjectOfType<FollowTarget>();
        _theLevelManager = FindObjectOfType<LevelManager>();
    }
        
    void Update()
    {
        if (_movePlayer)
        {
            _thePlayer.rb.velocity = new Vector3(_thePlayer.moveSpeed/2, _thePlayer.rb.velocity.y, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Triggered");
            StartCoroutine("LevelEndCo");
        }   
    }

    public IEnumerator LevelEndCo()
    {
        _thePlayer.canMove = false;
        _theCamera.isFollowingTarget = false;
        //_theLevelManager.Invincible = true;

        _thePlayer.rb.velocity = Vector3.zero;
        
        PlayerPrefs.SetInt("PlayerLives", _theLevelManager.currentLives);
        
        PlayerPrefs.SetInt(levelToUnlock, 1);
       
        ParticleSystem PS = Instantiate(finishLineParticle, transform);
        PS.Play();

        finishAudio.Play();
        
        
        yield return new WaitForSeconds(waitToMove);

        _movePlayer = true;
        
        yield return new WaitForSeconds(waitToLoad);
        SceneManager.LoadScene(levelToLoad);
        
    }




}
