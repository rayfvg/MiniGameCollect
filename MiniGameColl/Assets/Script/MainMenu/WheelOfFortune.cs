using UnityEngine;
using UnityEngine.SceneManagement;

public class WheelOfFortune : MonoBehaviour
{
    public float minSpinSpeed = 300f; // ����������� �������� ��������
    public float maxSpinSpeed = 600f; // ������������ �������� ��������
    public float minSpinDuration = 1f; // ����������� ������������ ��������
    public float maxSpinDuration = 3f; // ������������ ������������ ��������
    private float spinDuration; // ������� ������������ ��������
    private float spinSpeed; // ������� �������� ��������
    public bool isSpinning = false;
    private int numberOfSegments = 12;

    private void Awake()
    {
        ResetWheel();
    }
  

    void Update()
    {
        if (isSpinning)
        {
            spinDuration -= Time.deltaTime;
            if (spinDuration <= 0)
            {
                isSpinning = false;
                float finalAngle = transform.eulerAngles.z % 360;
                int segment = Mathf.FloorToInt(finalAngle / (360 / numberOfSegments));
                LoadScene(segment);
            }
            else
            {
                transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
            }
        }
    }

    public void SpinWheel()
    {
        if (!isSpinning)
        {
            spinSpeed = Random.Range(minSpinSpeed, maxSpinSpeed);
            spinDuration = Random.Range(minSpinDuration, maxSpinDuration);
            isSpinning = true;
        }
    }

    private void LoadScene(int segment)
    {
        int sceneIndex = (segment + 1) % numberOfSegments;
        SceneManager.LoadScene(sceneIndex);
    }

    private void ResetWheel()
    {
        spinDuration = 0;
        spinSpeed = 0;
        isSpinning = false;
        transform.rotation = Quaternion.identity; // ����� �������� ������
    }
}
