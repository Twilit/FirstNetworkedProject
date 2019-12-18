using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GenerateSnowball : NetworkBehaviour
{
    public GameObject snowball;

    float snowballSpawnDelay = 2f;
    float snowballTimer = 0f;

    void Start()
    {
        snowballTimer = snowballSpawnDelay;
    }

    void Update()
    {
        if (!isServer)
        {
            return;
        }

        snowballTimer -= Time.deltaTime;

        if (snowballTimer <= 0)
        {
            SpawnSnowball();

            snowballTimer = snowballSpawnDelay;
        }
    }

    void SpawnSnowball()
    {
        Vector3 spawnLocation = new Vector3(Random.Range(-9, 9), Random.Range(11, 14), 0);

        GameObject snowballGO = Instantiate(snowball, spawnLocation, Quaternion.identity);

        NetworkServer.Spawn(snowballGO);
    }
}
