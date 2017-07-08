using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleCircleStuff : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider other)
	{
		Destroy (other.gameObject);
		FindObjectOfType<GameManager> ().tapPressedBool = false;
		FindObjectOfType<GameManager> ().isGameOver = true;
		FindObjectOfType<GameManager> ().SetHighscoreScore ();
		FindObjectOfType<CameraMotor> ().reduceSpeed = true;
		//FindObjectOfType<CharacterMotor> ().speed = 0;
		if(SceneManager.GetActiveScene().name == "Game")
		{
			FindObjectOfType<CharacterMotor> ().speed = 0;
		}
		else if(SceneManager.GetActiveScene().name == "GameTilt")
		{
			FindObjectOfType<CharacterMotorTilt> ().speed = 0;
		}
		else if(SceneManager.GetActiveScene().name == "GameVR")
		{
			FindObjectOfType<CharacterMotorVR> ().speed = 0;
		}
		StartCoroutine (ReloadScene (2f));
	}

	IEnumerator ReloadScene(float time)
	{
		yield return new WaitForSeconds (time);

		FindObjectOfType<GameManager> ().isGameOver = false;

		if(SceneManager.GetActiveScene().name == "Game")
		{
			SceneManager.LoadScene ("Game");
		}
		else if(SceneManager.GetActiveScene().name == "GameTilt")
		{
			SceneManager.LoadScene ("GameTilt");
		}
		else if(SceneManager.GetActiveScene().name == "GameVR")
		{
			SceneManager.LoadScene ("GameVR");
		}
	}
}
