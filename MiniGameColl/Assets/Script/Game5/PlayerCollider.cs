using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{

    public ExpPLayerValue playerExp;
    public Timer timer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<FruintGame5>())
        {
            playerExp.AddExpValue(0.5f);
            Destroy(collision.gameObject.GetComponent<FruintGame5>());
        }
        else if (collision.gameObject.GetComponent<EnemyGame5>())
        {
            timer.GameOver();
        }
    }
}
