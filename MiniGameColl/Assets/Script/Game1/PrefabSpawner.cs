using System.Collections;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefab; // Префаб, который будет создаваться
    public Transform[] spawnPoints; // Массив мест для спавна префаба
    public float spawnInterval = 5f; // Интервал между спавнами

    void Start()
    {
        StartCoroutine(SpawnPrefabRoutine());
    }

    IEnumerator SpawnPrefabRoutine()
    {
        while (true)
        {
            SpawnPrefab();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnPrefab()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points assigned.");
            return;
        }

        // Выбираем случайное место из массива spawnPoints
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Создаем префаб в выбранной точке
        GameObject spawnedPrefab = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation, spawnPoint);

        // Уничтожаем префаб через 3 секунды
        Destroy(spawnedPrefab, 3f);
    }
}