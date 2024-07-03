using UnityEngine;

public class FrogController : MonoBehaviour
{
    public GameObject tonguePrefab; // Префаб языка лягушки
    public float tongueSpeed = 10f; // Скорость движения языка

    private Camera mainCamera;

    public Tongue jump;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if(jump.Stay.GetComponent<SpriteRenderer>().enabled == true) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Получаем позицию клика на экране
                Vector3 clickPosition = Input.mousePosition;
                clickPosition.z = mainCamera.nearClipPlane;

                // Конвертируем позицию клика в мировые координаты
                Vector3 worldPosition = mainCamera.ScreenToWorldPoint(clickPosition);

                // Создаем язык и направляем его к позиции клика
                GameObject tongue = Instantiate(tonguePrefab, transform.position, Quaternion.identity);
                tongue.GetComponent<Tongue>().Initialize(worldPosition, tongueSpeed);
            }
        }
    }
}
