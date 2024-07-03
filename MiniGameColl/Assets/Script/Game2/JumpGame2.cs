using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGame2 : MonoBehaviour
{
    public float jumpForce = 5f; // Сила прыжка
    public bool isGrounded;

    public GameObject GameOverScreen;

    public ExpPLayerValue PlayerExp;

    private Rigidbody2D rb;

    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
          //  anim.SetTrigger("jump");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<GroundGame2>())
        {
            isGrounded = true;
        }

        else if (collision.gameObject.GetComponent<Enemyobstacle>())
        {
            GameOverGame2();
        }
         
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        PlayerExp.AddExpValue(1f);
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

   public void GameOverGame2()
    {
        Time.timeScale = 0;
        GameOverScreen.SetActive(true);

    }
}

