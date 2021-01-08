using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//NOT object pooling; only instantiating/destroying objects so far

public class PlatformGenerator : MonoBehaviour
{
	public List<GameObject> platformPrefab = new List<GameObject>();
	public Transform player;

	public int numberOfPlatforms = 20;
	public float levelWidth = 2.2f;
	public float minY = .5f;
	public float maxY = 1.0f;

    private int random = 0;
	Vector3 spawnPosition = new Vector3(0,-3);

	// Use this for initialization
	void Start()
	{

		

		for (int i = 0; i < numberOfPlatforms; i++)
		{
			random = Random.Range(0, platformPrefab.Count);

			spawnPosition.y += Random.Range(minY, maxY);
			spawnPosition.x = Random.Range(-levelWidth, levelWidth);
			Instantiate(platformPrefab[random], spawnPosition, Quaternion.identity);
		}

	}

    private void Update()
    {
        if(player.position.y > spawnPosition.y - 20)
		{
			random = Random.Range(0, platformPrefab.Count);

			spawnPosition.y += Random.Range(minY, maxY);
			spawnPosition.x = Random.Range(-levelWidth, levelWidth);
			Instantiate(platformPrefab[random], spawnPosition, Quaternion.identity);
		}

	}
}
