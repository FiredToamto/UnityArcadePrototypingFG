using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPanner : MonoBehaviour
{
    public float MoveSpeed = 1f;

	// Update is called once per frame
	void Update ()
    {
        transform.position -= transform.right * MoveSpeed * Time.deltaTime;
	}
}