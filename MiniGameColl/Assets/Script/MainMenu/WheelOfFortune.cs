using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class WheelOfFortune : MonoBehaviour
{
    public Transform wheel; // Колесо (объект с ячейками)
    public float spinDuration = 5f; // Длительность вращения
    public float maxSpinSpeed = 500f; // Максимальная скорость вращения

    private bool isSpinning = false;
    private List<int> segmentIndexes = new List<int>(); // Список для хранения индексов сегментов

    void Start()
    {
        InitializeSegments();
    }

    void InitializeSegments()
    {
        // Заполняем список индексами сегментов
        for (int i = 0; i < 5; i++) // Здесь 5 - количество сегментов
        {
            segmentIndexes.Add(i);
        }

        // Перемешиваем индексы, чтобы значения были случайными
        ShuffleList(segmentIndexes);
    }

    void ShuffleList(List<int> list)
    {
        // Простой алгоритм тасования Фишера-Йейтса
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isSpinning) // Нажатие пробела запускает вращение
        {
            StartCoroutine(SpinTheWheel());
        }
    }

    IEnumerator SpinTheWheel()
    {
        isSpinning = true;
        float elapsedTime = 0f;
        float currentSpeed = maxSpinSpeed;

        while (elapsedTime < spinDuration)
        {
            wheel.Rotate(Vector3.forward, currentSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            currentSpeed = Mathf.Lerp(maxSpinSpeed, 0, elapsedTime / spinDuration);
            yield return null;
        }

        isSpinning = false;
        SnapToClosestSegment();
        LoadSceneBasedOnSegment();
    }

    void SnapToClosestSegment()
    {
        float segmentAngle = 360f / segmentIndexes.Count; // Угол для каждой ячейки
        float currentAngle = wheel.eulerAngles.z;
        float closestAngle = Mathf.Round(currentAngle / segmentAngle) * segmentAngle;

        wheel.eulerAngles = new Vector3(0, 0, closestAngle);
    }

    void LoadSceneBasedOnSegment()
    {
        float segmentAngle = 360f / segmentIndexes.Count;
        float currentAngle = wheel.eulerAngles.z;
        int segmentIndex = Mathf.RoundToInt(currentAngle / segmentAngle) % segmentIndexes.Count;

        int finalIndex = segmentIndexes[segmentIndex];
        string sceneToLoad = "Scene" + (finalIndex + 1); // Имя сцены должно соответствовать вашим сценам

        SceneManager.LoadScene(sceneToLoad);
    }
}



