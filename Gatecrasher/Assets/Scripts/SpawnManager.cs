using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public GameObject[] spawnPrefabs;

	private Transform playerTransform;
	private float spawnZ = 80.0f;
	private float spawnLength = 40.0f;
	private float safeZone = 40.0f;
	private int amnOnScreen = 5;

	//public int numberSpawned = 5;

	private List<GameObject> activePrefabs;

	// Use this for initialization
	void Start () 
	{
		activePrefabs = new List<GameObject>();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

		spawnZ = playerTransform.transform.position.z + 80f;

		for (int i = 0; i < amnOnScreen; i++)
		{
			SpawnPrefab ();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerTransform.position.z - safeZone > (spawnZ - amnOnScreen * spawnLength))
		{
			SpawnPrefab ();
//			numberSpawned++;
			DeletePrefab ();
		}
		
//
//		if (numberSpawned == 15)
//		{
//			StartCoroutine(WaitToSpawn(10f));
//		}
	}

//	IEnumerator WaitToSpawn(float time)
//	{
//		yield return new WaitForSeconds (time);
//
//		spawnZ = playerTransform.transform.position.z + 80f;
//		numberSpawned = 5;
//	}

	void SpawnPrefab(int prefabIndex = -1)
	{
		GameObject go;
		go = Instantiate (spawnPrefabs [0]) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;
		go.transform.rotation = Quaternion.AngleAxis (Random.Range (0, 360), Vector3.forward);
		spawnZ += spawnLength;
		activePrefabs.Add (go);
	}

	void DeletePrefab()
	{
		Destroy (activePrefabs [0]);
		activePrefabs.RemoveAt (0);
	}
}
