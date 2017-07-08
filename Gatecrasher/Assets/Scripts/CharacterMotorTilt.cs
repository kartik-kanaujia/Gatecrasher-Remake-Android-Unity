using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotorTilt : MonoBehaviour {

	public float speed = 30f;

	Quaternion to;

	float tilt = 0f;

	public GameObject leftUI;
	public GameObject rightUI;

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
			tilt = Input.acceleration.x;

			transform.Rotate (Vector3.forward, tilt * 8);
		}

	}

	void Update()
	{
		if (tilt > 0.1f)
		{
			rightUI.SetActive (false);
		}
		else
		if (tilt < -0.1f)
		{
			leftUI.SetActive (false);
		}
	}
}
