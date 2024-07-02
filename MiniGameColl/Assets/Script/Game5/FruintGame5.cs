using UnityEngine;

public class FruintGame5 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DestroerFruit>())
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.GetComponent<PlayerCollider>())
        {
            Destroy(gameObject);
        }
    }
}
