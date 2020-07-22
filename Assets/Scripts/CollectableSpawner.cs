using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public List<GameObject> spawnObjects;

    public int numberSpawned = 0;

    // object spawning logic
    public void Spawn(PlayerMovement.PlayerNumber playerNumber)
    {
        Collectable spawned = Instantiate(spawnObjects[Random.Range(0, spawnObjects.Count)], new Vector3(Random.Range(-6f, 6f), Random.Range(-2f, 2.5f), 0), Quaternion.identity).GetComponent<Collectable>();

        spawned.ownedBy = playerNumber;

        numberSpawned += 1;
    }











    // BELOW CODE IS FOR SPAWNING ON A TIMER

    //private bool spawning;

    //private float spawnTimer = 0f;

    //public float timeToSpawn;

    //// starts the spawning
    //private void Awake()
    //{
    //    spawning = false;
    //}

    //// spawn timing logic
    //private void Update()
    //{
    //    if (spawning)
    //    {
    //        if (spawnTimer >= timeToSpawn)
    //        {
    //            Spawn();

    //            spawnTimer = 0f;
    //        }

    //        spawnTimer += Time.deltaTime;
    //    }
    //}
}