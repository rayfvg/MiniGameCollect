using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFruit : MonoBehaviour
{
    public GameObject obstaclePrefab; // ������ �����������
    public float spawnRate = 2f; // ������� ������ �����������
    public float obstacleSpeed = 2f; // �������� �������� �����������

    private void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            GameObject obstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
            obstacle.GetComponent<FruinGame2Ob>().SetSpeed(obstacleSpeed);
        }
    }
}

