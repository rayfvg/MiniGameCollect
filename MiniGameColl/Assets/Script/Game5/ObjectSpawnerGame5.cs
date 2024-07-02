using UnityEngine;

public class ObjectSpawnerGame5 : MonoBehaviour
{
    public GameObject object1Prefab; // Префаб первого объекта
    public GameObject object2Prefab; // Префаб второго объекта
    public Transform[] spawnPoints; // Пять точек для спавна объектов
    public float spawnInterval = 2f; // Интервал спавна объектов
    public float objectSpeed = 2f; // Скорость движения объектов вниз

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

        GameObject prefabToSpawn = Random.value > 0.5f ? object1Prefab : object2Prefab;

        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity, spawnPoint);

        Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = spawnedObject.AddComponent<Rigidbody2D>();
        }

        rb.velocity = new Vector2(0, -objectSpeed);
    }
}
