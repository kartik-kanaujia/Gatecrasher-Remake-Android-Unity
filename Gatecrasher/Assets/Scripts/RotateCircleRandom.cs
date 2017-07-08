using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCircleRandom : MonoBehaviour {

	int randomInt = 0;

	// Use this for initialization
	void Start () {
		int random = Random.Range (0, 6);

		switch (random)
		{
			case 0:
				randomInt = 0;
				break;
			case 1:
				randomInt = -30;
				break;
			case 2:
				randomInt = 30;
				break;
			case 3:
				randomInt = 60;
				break;
			case 4:
				randomInt = -60;
				break;
			case 5:
				randomInt = 0;
				break;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.Rotate (Vector3.forward, randomInt * Time.deltaTime);
	}
}
