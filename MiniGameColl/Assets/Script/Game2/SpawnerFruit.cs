using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFruit : MonoBehaviour
{
    public GameObject obstaclePrefab; // ������ �����������
    public float spawnRate = 2f; // ������� ������ �����������
    public float obstacleSpeed = 2f; // �������� �������� �����������
    public Transform[] Spawnpos;

    private void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            GameObject obstacle = Instantiate(obstaclePrefab, Spawnpos[Random.Range(0, Spawnpos.Length)].position, Quaternion.identity.normalized, Spawnpos[1]); ;
            obstacle.GetComponent<FruinGame2Ob>().SetSpeed(obstacleSpeed);
        }
    }
}

