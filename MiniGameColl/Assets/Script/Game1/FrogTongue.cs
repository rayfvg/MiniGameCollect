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

        // ��������, ��������� �� ������ � ����� ��� ������ �������� ������
        if (screenPosition.x < Screen.width / 2)
        {
            // ����� ���������
            transform.localScale = new Vector3(0.7f, 0.7f, 0.7f); // ������������ �����
        }
        else
        {
            // ������ ���������
            transform.localScale = new Vector3(-0.7f, 0.7f, 0.7f); // ������������ ������
        }
    }
}


