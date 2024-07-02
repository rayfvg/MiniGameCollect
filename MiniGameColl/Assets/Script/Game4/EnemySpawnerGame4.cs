using UnityEngine;

public class EnemySpawnerGame4 : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага
    public GameObject FruitPrefab; // Префаб врага
    public Transform[] spawnPoints; // Массив точек спауна
    public float spawnRate = 2f; // Частота спауна врагов

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnRate);
    }

    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = Random.value > 0.5f ? FruitPrefab : enemyPrefab;
        // Выбираем случайную точку спауна
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Создаем врага в выбранной точке спауна
        Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity, spawnPoint);
    }
}

