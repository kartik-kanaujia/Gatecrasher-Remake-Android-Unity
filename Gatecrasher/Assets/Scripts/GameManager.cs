using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VR;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject countdownGo;
	public Text countdownText;
	public GameObject tapGo;

	public GameObject spawnManager;

	public AudioSource lowBeep;
	public AudioSource highBeep;

	public bool tapPressedBool = false;
	public bool isGameOver = false;

	public int tempScore = 0;

	public Text scoreText;
	public GameObject scoreTextGo;

	public Text highscoreText;

	// Use this for initialization
	void Start () 
	{
		if (highscoreText)
		{
			highscoreText.text = PlayerPrefs.GetInt ("score").ToString ();
		}

		if (scoreText)
		{
			scoreText.text = "0";
		}
	}
	
	// Update is called once per frame
	void Update () {

//		scoreText.text = tempScore.ToString ();

		if (SceneManager.GetActiveScene ().name == "Menu")
		{
			VRSettings.enabled = false;

			if (Input.GetKeyDown(KeyCode.Escape)) 
			{
				Application.Quit();
			}

			Screen.orientation = ScreenOrientation.Portrait;
		}

		else if (SceneManager.GetActiveScene ().name == "Game")
		{
			VRSettings.enabled = false;

			if (Input.GetKeyDown(KeyCode.Escape)) 
			{
				SceneManager.LoadScene ("Menu");
			}

			Screen.autorotateToPortrait = true;
			Screen.autorotateToLandscapeLeft = true;
			Screen.autorotateToLandscapeRight = true;

			Screen.orientation = ScreenOrientation.AutoRotation;
		}

		else if (SceneManager.GetActiveScene ().name == "GameTilt")
		{
			VRSettings.enabled = false;

			if (Input.GetKeyDown(KeyCode.Escape)) 
			{
				SceneManager.LoadScene ("Menu");
			}

			Screen.orientation = ScreenOrientation.LandscapeLeft;
		}

		else if (SceneManager.GetActiveScene ().name == "GameVR")
		{
			VRSettings.enabled = true;

			if (Input.GetKeyDown(KeyCode.Escape)) 
			{
				SceneManager.LoadScene ("Menu");
			}

			Screen.orientation = ScreenOrientation.LandscapeLeft;
		}

	}

	public void SetHighscoreScore()
	{
		if (PlayerPrefs.GetInt ("score") < tempScore)
		{
			PlayerPrefs.SetInt ("score",tempScore);
		}
	}

	public void IncrementScore()
	{
		tempScore++;
		scoreText.text = tempScore.ToString ();
	}

	public void TapPressed()
	{
		tapGo.SetActive (false);

		tapPressedBool = true;

		StartCoroutine(WaitToStart0(0f));
		StartCoroutine(WaitToStart1(1f));
		StartCoroutine(WaitToStart2(2f));
		StartCoroutine(WaitToStart3(3f));
		StartCoroutine(WaitToStart4(3.5f));
	}

	IEnumerator WaitToStart0(float time)
	{
		yield return new WaitForSeconds (time);

		countdownText.text = "3";
		lowBeep.Play ();
	}
	IEnumerator WaitToStart1(float time)
	{
		yield return new WaitForSeconds (time);

		countdownText.text = "2";
		lowBeep.Play ();
	}
	IEnumerator WaitToStart2(float time)
	{
		yield return new WaitForSeconds (time);

		countdownText.text = "1";
		lowBeep.Play ();
	}
	IEnumerator WaitToStart3(float time)
	{
		yield return new WaitForSeconds (time);

		countdownText.text = "GO";
		highBeep.Play ();
		spawnManager.SetActive (true);
	}
	IEnumerator WaitToStart4(float time)
	{
		yield return new WaitForSeconds (time);

		countdownGo.SetActive (false);
		scoreTextGo.SetActive (true);
	}

	public void LoadLevel(string level)
	{
		SceneManager.LoadScene (level);
	}
}
