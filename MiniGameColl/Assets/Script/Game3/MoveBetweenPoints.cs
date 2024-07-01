using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    public Transform leftPoint; // Левая точка
    public Transform centerPoint; // Центральная точка
    public Transform rightPoint; // Правая точка
    public float moveSpeed = 5f; // Скорость движения

    private Transform targetPoint; // Целевая точка

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

        // Плавное перемещение к целевой точке
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);
    }
}
