using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    public Transform leftPoint; // Левая точка
    public Transform centerPoint; // Центральная точка
    public Transform rightPoint; // Правая точка
    public float moveSpeed = 5f; // Скорость движения

    private Transform targetPoint; // Целевая точка

    public AudioSource Move;

    private void Start()
    {
        targetPoint = centerPoint; // Начальная позиция - центральная точка
    }

    private void Update()
    {
        // Обработка ввода
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

        // Плавное перемещение к целевой точке
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
