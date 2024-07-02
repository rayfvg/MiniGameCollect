using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGame4 : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;

    public float Speed = 2f;
    public float RotationSpeed = 1.9f;

    public bool check = false;

    public GameObject Player;
    public Timer Timer;

    public ExpPLayerValue PlayerExp;

    private void Update()
    {
        if (check) transform.position = Vector3.MoveTowards(transform.position, target1.transform.position, Speed * Time.deltaTime);
        if (!check) transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, Speed * Time.deltaTime);

        transform.rotation *= Quaternion.Euler(0, 0, 1.9f);

      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyMoverGame4>())
        {
            Timer.GameOver();
        }
        else if (collision.gameObject.GetComponent<FruintMoverGame4>())
        {
            PlayerExp.AddExpValue(0.7f);
            Destroy(collision.gameObject.GetComponent<FruintMoverGame4>());
        }
    }

    public void change()
    {
        check = !check;
    }

   
}
