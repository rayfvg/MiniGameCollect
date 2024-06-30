using UnityEngine;

public class Tongue : MonoBehaviour
{
    private Vector3 targetPosition;
    private float speed;

    public ExpPLayerValue expPlayer;

    public void Initialize(Vector3 targetPosition, float speed)
    {
        this.targetPosition = targetPosition;
        this.speed = speed;
    }

    void Update()
    {
        // ������� ���� � ����
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // ���������� ����, ���� �� ������ ����
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // ���������� ������ ��� ���������������
        Destroy(other.gameObject);

        expPlayer.AddExpValue(0.4f);

        // ���������� ����
        Destroy(gameObject);
    }
}
