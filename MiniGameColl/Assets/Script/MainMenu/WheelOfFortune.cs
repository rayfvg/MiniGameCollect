using UnityEngine;
using UnityEngine.SceneManagement;

public class WheelOfFortune : MonoBehaviour
{
    public float minSpinSpeed = 300f; // Минимальная скорость вращения
    public float maxSpinSpeed = 600f; // Максимальная скорость вращения
    public float minSpinDuration = 1f; // Минимальная длительность вращения
    public float maxSpinDuration = 3f; // Максимальная длительность вращения
    private float spinDuration; // Текущая длительность вращения
    private float spinSpeed; // Текущая скорость вращения
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
        transform.rotation = Quaternion.identity; // Сброс вращения колеса
    }
}
