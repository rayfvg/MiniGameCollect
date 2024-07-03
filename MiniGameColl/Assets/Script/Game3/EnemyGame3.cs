using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGame3 : MonoBehaviour
{

    public float rotationSpeed = 100f; // �������� �������� � �������� � �������

    void Update()
    {
        // ������� ������ ������ ��� Z (����� �������� ���� � ��������� XY)
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DestroerFruit>() || collision.gameObject.GetComponent<ExpPLayerValue>())
        {
            Destroy(gameObject);
        }
    }
}
