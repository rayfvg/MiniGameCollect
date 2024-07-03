using UnityEngine;

public class FrogTongue : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(transform.position);

        // Проверка, находится ли спрайт в левой или правой половине экрана
        if (screenPosition.x < Screen.width / 2)
        {
            // Левое положение
            transform.localScale = new Vector3(0.7f, 0.7f, 0.7f); // Поворачиваем влево
        }
        else
        {
            // Правое положение
            transform.localScale = new Vector3(-0.7f, 0.7f, 0.7f); // Поворачиваем вправо
        }
    }
}


