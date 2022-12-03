using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    InputActions inputActions;

    Rigidbody2D rb;

    float fuerzSalto = 16f;

    bool saltando = false;

    Animator anim;

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.Anubis.Jump.started += _ => Saltar();

        GameManager.alive = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

    }


    void Saltar()
    {
        if(saltando == false)
        {
            rb.AddForce(Vector2.up * fuerzSalto, ForceMode2D.Impulse);
            saltando = true;
            anim.SetTrigger("Jump");
            anim.SetBool("IsGrounded", false);
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            saltando = false;
            anim.SetBool("IsGrounded", true);
        }
       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            //saltando = false;
            anim.SetBool("IsGrounded", false);
        }

    }

    private void Update()
    {
        anim.SetFloat("FallingVelocity", rb.velocity.y);
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}
