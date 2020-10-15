using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLooper : MonoBehaviour
{
    public Transform BackgroundTr;
    public int LoopCounter = 0;
    public float LoopPos;
    public float BackgroundPosX;
    public float Width;
    public float Units;


	// Use this for initialization
	void Start ()
    {
        BackgroundTr = GetComponent<Transform>();
        Width = GetComponent<SpriteRenderer>().bounds.size.x - 2;
        LoopPos = -Width;
	}
	
	// Update is called once per frame
	void Update ()
    {
        BackgroundPosX = BackgroundTr.position.x;
        if (BackgroundPosX <= LoopPos)
        {
            LoopCounter = LoopCounter + 1;
            BackgroundTr.position = new Vector2(Width * Units, BackgroundTr.position.y);
        }
    }
}
