using System.Collections;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefab; // ������, ������� ����� �����������
    public Transform[] spawnPoints; // ������ ���� ��� ������ �������
    public float spawnInterval = 5f; // �������� ����� ��������

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

        // �������� ��������� ����� �� ������� spawnPoints
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // ������� ������ � ��������� �����
        GameObject spawnedPrefab = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation, spawnPoint);

        // ���������� ������ ����� 3 �������
        Destroy(spawnedPrefab, 3f);
    }
}