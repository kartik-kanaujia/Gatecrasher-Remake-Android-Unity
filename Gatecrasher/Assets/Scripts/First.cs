using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.VR;

public class First : MonoBehaviour {

	//public GameObject loadingImage;
	public Slider loadingBar;
	public GameObject loadingImage;

	private AsyncOperation async;

	// Use this for initialization
	void Start () 
	{
		VRSettings.enabled = false;
		StartCoroutine (ExecuteAfterTime (2f));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {Application.Quit();}
	}

	IEnumerator ExecuteAfterTime (float time)
	{
		yield return new WaitForSeconds (time);
			
		loadingImage.SetActive (true);
		StartCoroutine (LoadLevelWithBar (1));
		//SceneManager.LoadScene ("Game");
	}
	IEnumerator LoadLevelWithBar (int level)
	{
		async = SceneManager.LoadSceneAsync (level);
		while (!async.isDone)
		{
			loadingBar.value = async.progress;
			yield return null;
		}
	}
}
