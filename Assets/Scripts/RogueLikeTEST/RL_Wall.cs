using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL_Wall : MonoBehaviour
{

    public Sprite dmgSprite;
    public int hp = 4;

    private SpriteRenderer _spriteRenderer;



    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DamageWall (int loss)
    {

        _spriteRenderer.sprite = dmgSprite;
        hp -= loss;
        if (hp <= 0)
            gameObject.SetActive(false);

    }
}
