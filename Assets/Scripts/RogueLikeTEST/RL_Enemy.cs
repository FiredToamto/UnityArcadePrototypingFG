using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL_Enemy : RL_MovingObject
{
    public int playerDamage;

    private Animator animator;
    private Transform target;
    private bool skipMove;
       
    
    // Start is called before the first frame update
    protected override void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectsWithTag("Player").transform;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void AttemptMove <T> (int xDir, int yDir)
    {
        if (skipMove)
        {
            skipMove = false;
            return;
        }

        base.AttemptMove<T>(xDir, yDir);

        skipMove = true;
    }

    public void moveEnemy()
    {

        int xDir = 0;
        int yDir = 0;

        if (Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon)
            yDir = target.position.y > transform.position.y ? 1 : -1;
        else
            xDir = target.position.x > transform.position.x ? 1 : -1;
        AttemptMove <Player> (xDir, yDir);
    }

    protected override void onCantMove<T>(T component)
    {
        PlayerPrefs hitPlayer = component as Player;
        hitPlayer.LoseFood(playerDamage);

        throw new System.NotImplementedException();
    }




}
