using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    public Transform leftPoint; // ����� �����
    public Transform centerPoint; // ����������� �����
    public Transform rightPoint; // ������ �����
    public float moveSpeed = 5f; // �������� ��������

    private Transform targetPoint; // ������� �����

    private void Start()
    {
        targetPoint = centerPoint; // ��������� ������� - ����������� �����
    }

    private void Update()
    {
        // ��������� �����
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (targetPoint == centerPoint)
            {
                targetPoint = leftPoint;
            }
            else if (targetPoint == rightPoint)
            {
                targetPoint = centerPoint;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (targetPoint == centerPoint)
            {
                targetPoint = rightPoint;
            }
            else if (targetPoint == leftPoint)
            {
                targetPoint = centerPoint;
            }
        }

        // ������� ����������� � ������� �����
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);
    }
}
