using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;


    public float hitrost = 22f;
    public float premik;
    public float skok;
    private bool isGrounded;
    public float radij;
    public LayerMask tla;
    public Joystick joystick;

    public Animator anim;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }   
    void FixedUpdate()
    {

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        
        premik = joystick.Horizontal;
        
        rb.velocity = new Vector2(premik * hitrost, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(transform.position, radij, tla);  

        if (Input.GetKey("w") && isGrounded)
        {
            anim.SetInteger("Run", 2);
            rb.velocity = Vector2.up * skok;
        }
        else if (premik < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            anim.SetInteger("Run", 1);
        }
        else if (premik > 0)
        {
            anim.SetInteger("Run", 1);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
        if (!Input.anyKey)
        {
            anim.SetInteger("Run", 0);
        }
    }






    void Enabled()
    {
        anim.SetBool("Jumping", true);
    }
    void Disabled()
    {
        anim.SetBool("Jumping", false);
    }

}
