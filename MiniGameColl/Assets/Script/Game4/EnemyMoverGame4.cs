using UnityEngine;

public class EnemyMoverGame4 : MonoBehaviour
{
    public float moveSpeed = 2f; // �������� ��������

    private void Update()
    {
        // ������� ����� �����
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

        // �������� �����, ���� �� ������� �� ������� ������
        if (transform.position.y > 10f) // ��������� �������� �� �������������
        {
            Destroy(gameObject);
        }
    }
}
