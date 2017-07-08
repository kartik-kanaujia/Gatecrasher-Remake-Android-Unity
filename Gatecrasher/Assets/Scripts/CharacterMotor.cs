using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour {

	public bool leftTrue = false;
	public bool rightTrue = false;

	public float speed = 30f;

	Quaternion to;
	Quaternion modelTo;

	public GameObject model;

	public GameObject leftButton;
	public GameObject rightButton;


	public float tempLeft = 0f;
	public float tempRight = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.position += Vector3.forward * speed * Time.deltaTime;

		if (FindObjectOfType<GameManager> ().tapPressedBool == true)
		{
			Quaternion temp = transform.rotation;

			if (leftTrue == true)
			{
				to = Quaternion.AngleAxis (tempLeft - 5f, Vector3.forward) * transform.rotation;
				if (tempLeft <= -20f)
				{
					tempLeft = -20f;
				}
				else
				{
					tempLeft -= 0.5f;
				}
				//modelTo = Quaternion.AngleAxis (-30, transform.up) * transform.rotation;
			}

			if (rightTrue == true)
			{
				to = Quaternion.AngleAxis (tempRight + 5f, Vector3.forward) * transform.rotation;
				if (tempRight >= 20f)
				{
					tempRight = 20f;
				}
				else
				{
					tempRight += 0.5f;
				}
				//modelTo = Quaternion.AngleAxis (30, transform.up) * transform.rotation;
				//transform.Rotate(Vector3.forward * 100 * Time.deltaTime);
			}

			if (rightTrue == false && leftTrue == false)
			{
				tempLeft = 0f;
				tempRight = 0f;
				//to = Quaternion.AngleAxis (0, Vector3.forward) * transform.rotation;
			}

			transform.rotation = Quaternion.Slerp (transform.rotation, to, 15 * Time.deltaTime);
			//model.transform.rotation = Quaternion.Lerp (model.transform.rotation, modelTo, 0.5f * Time.deltaTime);


		}
	}

	void Update()
	{
		if (speed == 0)
		{
			leftButton.SetActive (false);
			rightButton.SetActive (false);
		}
	}

	public void LeftPressed()
	{
		leftTrue = true;
	}

	public void LeftReleased()
	{
		leftTrue = false;
	}

	public void RightPressed()
	{
		rightTrue = true;
	}

	public void RightReleased()
	{
		rightTrue = false;
	}
}
