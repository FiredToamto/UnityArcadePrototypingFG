using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    
    private Vector2 _offset;
    private Material _myMat;
    // Start is called before the first frame update
    void Start()
    {
        _myMat = GetComponent<Renderer>().material;
        _offset = new Vector2(0, scrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        _myMat.mainTextureOffset += _offset * Time.deltaTime;
    }
}
