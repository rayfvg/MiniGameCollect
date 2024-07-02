using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class WheelOfFortune : MonoBehaviour
{
    public Transform wheel; // ������ (������ � ��������)
    public float spinDuration = 5f; // ������������ ��������
    public float maxSpinSpeed = 500f; // ������������ �������� ��������

    private bool isSpinning = false;
    private List<int> segmentIndexes = new List<int>(); // ������ ��� �������� �������� ���������

    void Start()
    {
        InitializeSegments();
    }

    void InitializeSegments()
    {
        // ��������� ������ ��������� ���������
        for (int i = 0; i < 5; i++) // ����� 5 - ���������� ���������
        {
            segmentIndexes.Add(i);
        }

        // ������������ �������, ����� �������� ���� ����������
        ShuffleList(segmentIndexes);
    }

    void ShuffleList(List<int> list)
    {
        // ������� �������� ��������� ������-������
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
        if (Input.GetKeyDown(KeyCode.Space) && !isSpinning) // ������� ������� ��������� ��������
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
        float segmentAngle = 360f / segmentIndexes.Count; // ���� ��� ������ ������
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
        string sceneToLoad = "Scene" + (finalIndex + 1); // ��� ����� ������ ��������������� ����� ������

        SceneManager.LoadScene(sceneToLoad);
    }
}



