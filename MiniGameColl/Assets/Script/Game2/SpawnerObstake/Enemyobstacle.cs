using UnityEngine;

public class Enemyobstacle : MonoBehaviour
{
    private float speed;

    public void SetSpeed(float obstacleSpeed)
    {
        speed = obstacleSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // �������� �����������, ���� ��� ������� �� ������� ������
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}