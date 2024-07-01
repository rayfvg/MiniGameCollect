using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruinGame2Ob : MonoBehaviour
{
    private float speed;

    public void SetSpeed(float obstacleSpeed)
    {
        speed = obstacleSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Удаление препятствия, если оно выходит за пределы экрана
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
