using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGame3 : MonoBehaviour
{

    public float rotationSpeed = 100f; // Скорость вращения в градусах в секунду

    void Update()
    {
        // Вращаем объект вокруг оси Z (чтобы вращение было в плоскости XY)
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DestroerFruit>() || collision.gameObject.GetComponent<ExpPLayerValue>())
        {
            Destroy(gameObject);
        }
    }
}
