using UnityEngine;

public class ColliderPlayer : MonoBehaviour
{

    public ExpPLayerValue player;
    public Timer timer;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<FruinGame3>())
        {
            player.AddExpValue(0.6f);
        }
        else if (collision.gameObject.GetComponent<EnemyGame3>())
        {
            timer.GameOver();
        }
    }

}
