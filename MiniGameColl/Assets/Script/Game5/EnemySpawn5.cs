using UnityEngine;

public class EnemySpawn5 : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага
    public Transform spawnPoint; // Точка спавна врага
    public float spawnInterval = 2f; // Интервал спавна врагов
    public float enemySpeed = 2f; // Скорость движения врагов вниз

    private float timeSinceLastSpawn;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnEnemy()
    {
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);

       
    }
}

