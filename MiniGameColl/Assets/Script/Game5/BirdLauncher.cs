using UnityEngine;

public class BirdLauncher : MonoBehaviour
{
    public Rigidbody2D birdRigidbody;
    public float launchForce = 500f;
    public LineRenderer leftLine;
    public LineRenderer rightLine;
    public Transform leftAnchor;
    public Transform rightAnchor;
    public float maxDragRadius = 2f;
    public Transform spawnPoint; // Точка старта птички

    private Vector2 startPos;
    private bool isDragging = false;

    void Start()
    {
        startPos = spawnPoint.position; // Используем точку старта для начальной позиции
        ResetBird();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(mousePos, birdRigidbody.position) < 0.5f)
            {
                isDragging = true;
            }
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            Vector2 currentPos = birdRigidbody.position;
            Vector2 direction = startPos - currentPos;
            birdRigidbody.isKinematic = false;
            birdRigidbody.AddForce(direction * launchForce);
            birdRigidbody.gravityScale = 1;

            leftLine.enabled = false;
            rightLine.enabled = false;
        }

        if (isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dragVector = mousePos - startPos;
            if (dragVector.magnitude > maxDragRadius)
            {
                dragVector = dragVector.normalized * maxDragRadius;
            }
            birdRigidbody.position = startPos + dragVector;
            DrawRubberBand();
        }
    }

    void DrawRubberBand()
    {
        leftLine.enabled = true;
        rightLine.enabled = true;

        leftLine.SetPosition(0, leftAnchor.position);
        leftLine.SetPosition(1, birdRigidbody.position);

        rightLine.SetPosition(0, rightAnchor.position);
        rightLine.SetPosition(1, birdRigidbody.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        ResetBird();
    }

    private void ResetBird()
    {
        birdRigidbody.velocity = Vector2.zero;
        birdRigidbody.angularVelocity = 0f;
        birdRigidbody.isKinematic = true;
        birdRigidbody.gravityScale = 0;
        birdRigidbody.position = startPos;
        //leftLine.enabled = true;
        //rightLine.enabled = true;
    }


}
