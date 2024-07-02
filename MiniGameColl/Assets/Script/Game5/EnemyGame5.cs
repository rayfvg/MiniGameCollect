using UnityEngine;

public class EnemyGame5 : MonoBehaviour
{
    public float speed = 2f; // Скорость движения объекта вверх
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Двигаем объект вверх
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // Проверяем, вышел ли объект за пределы экрана
        Vector3 screenPosition = mainCamera.WorldToViewportPoint(transform.position);
        if (screenPosition.y > 1)
        {
            Destroy(gameObject); // Уничтожаем объект
        }
    }

    
}

