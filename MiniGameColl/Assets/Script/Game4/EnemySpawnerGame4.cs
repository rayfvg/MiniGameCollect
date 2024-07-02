using UnityEngine;

public class EnemySpawnerGame4 : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �����
    public GameObject FruitPrefab; // ������ �����
    public Transform[] spawnPoints; // ������ ����� ������
    public float spawnRate = 2f; // ������� ������ ������

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnRate);
    }

    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = Random.value > 0.5f ? FruitPrefab : enemyPrefab;
        // �������� ��������� ����� ������
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // ������� ����� � ��������� ����� ������
        Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity, spawnPoint);
    }
}

