using UnityEngine;

public class EnemyGame5 : MonoBehaviour
{
    public float speed = 2f; // �������� �������� ������� �����
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // ������� ������ �����
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // ���������, ����� �� ������ �� ������� ������
        Vector3 screenPosition = mainCamera.WorldToViewportPoint(transform.position);
        if (screenPosition.y > 1)
        {
            Destroy(gameObject); // ���������� ������
        }
    }

    
}

