using UnityEngine;

public class FruintMoverGame4 : MonoBehaviour
{
    public float moveSpeed = 2f; // Скорость движения

    private void Update()
    {
        // Двигаем врага вверх
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

        // Удаление врага, если он выходит за пределы экрана
        if (transform.position.y > 10f) // Настройте значение по необходимости
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
