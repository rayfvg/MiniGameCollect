using UnityEngine;

public class FruinGame3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DestroerFruit>() || collision.gameObject.GetComponent<ExpPLayerValue>())
        {
            Destroy(gameObject);
        }
    }
}
