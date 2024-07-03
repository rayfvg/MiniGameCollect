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
    private SpriteRenderer rander;

    public Animator anim;
    public Timer timerrr;

    public Sprite Jump;
    public Sprite Stay;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rander = GetComponent<SpriteRenderer>();    
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    //    {
    //        rander.sprite = Jump;
    //        rb.AddForce(Vector2.up * 8f, ForceMode2D.Impulse);
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<GroundGame2>())
        {
            isGrounded = true;
            rander.sprite = Stay;
        }

        else if (collision.gameObject.GetComponent<Enemyobstacle>())
        {
            timerrr.GameOver();
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

  public void Jumping()
    {
        if (isGrounded)
        {
            rander.sprite = Jump;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
        }
    }
}

