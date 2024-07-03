using UnityEngine;

public class Tongue : MonoBehaviour
{
    private Vector3 targetPosition;
    private float speed;

    public GameObject Stay;

    public ExpPLayerValue expPlayer;

    public bool Jumping = true;

    public void Initialize(Vector3 targetPosition, float speed)
    {
        Jumping = false;
        this.targetPosition = targetPosition;
        this.speed = speed;
        Stay.GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update()
    {
        
        // ƒвигаем €зык к цели
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        // ”ничтожаем €зык, если он достиг цели
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            Destroy(gameObject);
            Stay.GetComponent<SpriteRenderer>().enabled = true;
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // ”ничтожаем объект при соприкосновении
        Destroy(other.gameObject);

        expPlayer.AddExpValue(0.4f);

        // ”ничтожаем €зык
        Destroy(gameObject);
        Stay.GetComponent<SpriteRenderer>().enabled = true;
        
    }
}
