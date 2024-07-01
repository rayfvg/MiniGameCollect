using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Префаб препятствия
    public float spawnRate = 2f; // Частота спавна препятствий
    public float obstacleSpeed = 2f; // Скорость движения препятствия

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
            obstacle.GetComponent<Enemyobstacle>().SetSpeed(obstacleSpeed);
        }
    }
}
