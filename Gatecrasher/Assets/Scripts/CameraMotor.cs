using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

	public float speed = 30f;
	public bool reduceSpeed = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += Vector3.forward * speed * Time.deltaTime;

		if (reduceSpeed == true)
		{
			speed -= 15f * Time.deltaTime;
		}
		if (speed <= 0)
		{
			speed = 0;
		}
	}
}
