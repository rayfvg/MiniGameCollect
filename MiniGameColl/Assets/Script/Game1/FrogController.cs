using UnityEngine;

public class FrogController : MonoBehaviour
{
    public GameObject tonguePrefab; // ������ ����� �������
    public float tongueSpeed = 10f; // �������� �������� �����

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
                // �������� ������� ����� �� ������
                Vector3 clickPosition = Input.mousePosition;
                clickPosition.z = mainCamera.nearClipPlane;

                // ������������ ������� ����� � ������� ����������
                Vector3 worldPosition = mainCamera.ScreenToWorldPoint(clickPosition);

                // ������� ���� � ���������� ��� � ������� �����
                GameObject tongue = Instantiate(tonguePrefab, transform.position, Quaternion.identity);
                tongue.GetComponent<Tongue>().Initialize(worldPosition, tongueSpeed);
            }
        }
    }
}
