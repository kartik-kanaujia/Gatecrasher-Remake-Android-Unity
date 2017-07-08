using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotorVR : MonoBehaviour {

	public float speed = 30f;

	Quaternion to;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.position += Vector3.forward * speed * Time.deltaTime;

		if (FindObjectOfType<GameManager> ().tapPressedBool == true)
		{
			float tilt = Input.acceleration.x;

			transform.Rotate (Vector3.forward, tilt * 8);

		}


	}
}
