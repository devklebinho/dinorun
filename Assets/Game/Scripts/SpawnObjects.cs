using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject objectsToSpawn;
    public float spawnInterval = 0.5f;

    void Start()
    {
        spawnPoint = this.transform;
        InvokeRepeating("Spawn", 0f, spawnInterval);
    }

    public void Spawn()
    {
        Instantiate(objectsToSpawn, spawnPoint.position, spawnPoint.rotation);
    }

}
