using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    public Transform leftPoint; // ����� �����
    public Transform centerPoint; // ����������� �����
    public Transform rightPoint; // ������ �����
    public float moveSpeed = 5f; // �������� ��������

    private Transform targetPoint; // ������� �����

    public AudioSource Move;

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
                Move.Play();
            }
            else if (targetPoint == rightPoint)
            {
                targetPoint = centerPoint;
                Move.Play();
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (targetPoint == centerPoint)
            {
                targetPoint = rightPoint;
                Move.Play();
            }
            else if (targetPoint == leftPoint)
            {
                targetPoint = centerPoint;
                Move.Play();
            }
        }

        // ������� ����������� � ������� �����
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);
    }

    public void MoveRight()
    {
        if (targetPoint == centerPoint)
        {
            targetPoint = rightPoint;
            Move.Play();
        }
        else if (targetPoint == leftPoint)
        {
            targetPoint = centerPoint;
            Move.Play();
        }
    }

    public void MoveLeft()
    {
        if (targetPoint == centerPoint)
        {
            targetPoint = leftPoint;
            Move.Play();
        }
        else if (targetPoint == rightPoint)
        {
            targetPoint = centerPoint;
            Move.Play();
        }
    }
}
