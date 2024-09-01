using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject objectToSpawn;
    public int poolSize = 10;
    public float spawnInterval = 0.5f;

    private List<GameObject> objectPool;
    private int currentIndex = 0;

    void Start()
    {
        // Inicializa o ponto de spawn
        spawnPoint = this.transform;

        // Cria a pool de objetos
        objectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
            obj.SetActive(false); 
            objectPool.Add(obj);
        }

        InvokeRepeating("Spawn", 0f, spawnInterval);
    }

    public void Spawn()
    {
        GameObject obj = objectPool[currentIndex];
        obj.transform.position = spawnPoint.position;
        obj.transform.rotation = spawnPoint.rotation;
        obj.SetActive(true);

        currentIndex = (currentIndex + 1) % poolSize;
    }
}
