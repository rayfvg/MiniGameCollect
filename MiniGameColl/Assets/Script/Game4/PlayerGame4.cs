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

    private void Update()
    {
        if (check) transform.position = Vector3.MoveTowards(transform.position, target1.transform.position, Speed * Time.deltaTime);
        if (!check) transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, Speed * Time.deltaTime);

        transform.rotation *= Quaternion.Euler(0, 0, 1.9f);

      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "goal")
        {
            print("take");
            check = false;

            target1.SetActive(false);
            target1.transform.position = new Vector3(transform.position.x, target1.transform.position.y, transform.position.z);
            target2.SetActive(true);
            target2.transform.position = new Vector3(transform.position.x, Random.Range(-2f, 2f), transform.position.z);
        }
    }

    public void change()
    {
        check = !check;
        print("tap");
    }

   
}
