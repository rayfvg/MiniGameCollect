using UnityEngine;

public class EnemySpawn5 : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �����
    public Transform spawnPoint; // ����� ������ �����
    public float spawnInterval = 2f; // �������� ������ ������
    public float enemySpeed = 2f; // �������� �������� ������ ����

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

