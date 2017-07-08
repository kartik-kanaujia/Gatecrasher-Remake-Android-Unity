using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

	public AudioSource ambient;
	public AudioSource gameplay;
	public AudioSource hit;

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (SceneManager.GetActiveScene ().name == "Menu")
		{
			gameplay.enabled = false;
			ambient.enabled = true;
			hit.enabled = false;
		}

		else if (FindObjectOfType<GameManager> ().tapPressedBool == true && FindObjectOfType<GameManager> ().isGameOver == false)
		{
			gameplay.enabled = true;
			ambient.enabled = false;
			hit.enabled = false;
		}

		else if (FindObjectOfType<GameManager> ().isGameOver == true)
		{
			gameplay.enabled = false;
			ambient.enabled = false;
			hit.enabled = true;
		}
	}
}
