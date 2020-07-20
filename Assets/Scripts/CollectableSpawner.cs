using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public List<GameObject> spawnObjects;

    private bool playing;

    private float spawnTimer = 0f;

    public float timeToSpawn;

    public int numberSpawned;

    // starts the spawning
    private void Awake()
    {
        playing = true;

        numberSpawned = 0;
    }

    // spawn timing logic
    private void Update()
    {
        if (playing)
        {
            if (spawnTimer >= timeToSpawn)
            {
                Spawn();

                spawnTimer = 0f;
            }

            spawnTimer += Time.deltaTime;
        }
    }

    // object spawning logic
    private void Spawn()
    {
        Instantiate(spawnObjects[Random.Range(0, spawnObjects.Count)], new Vector3(Random.Range(-6f, 6f), Random.Range(-2f, 2.5f), 0), Quaternion.identity);
        numberSpawned += 1;
    }
}