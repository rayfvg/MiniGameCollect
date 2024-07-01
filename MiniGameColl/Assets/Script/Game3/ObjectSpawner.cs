using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject berryPrefab;      // Префаб ягоды
    public GameObject obstaclePrefab;   // Префаб препятствия
    public Transform[] spawnPoints;     // Массив точек спавна

    public float spawnInterval = 2f;    // Интервал спавна объектов
    public float objectSpeed = 2f;      // Скорость движения объектов вни

    private float timeSinceLastSpawn;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObject();
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnObject()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        GameObject prefabToSpawn = Random.value > 0.5f ? berryPrefab : obstaclePrefab;

        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity, spawnPoint);

        Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = spawnedObject.AddComponent<Rigidbody2D>();
        }

        rb.velocity = new Vector2(0, -objectSpeed);
    }
}

