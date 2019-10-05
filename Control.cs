using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed = 5.0f;
    public float jumpForce = 700f;

    public Animator anim;

    private bool IsGrounded;
    public Transform GroundCheck;
    private float groundRadius = 0.2f;
    public LayerMask groundLayers;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}

    void Update()
    {
        if(IsGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    // Update is called once per frame
    void FixedUpdate () {

        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, groundRadius, groundLayers);
        anim.SetBool("Ground", IsGrounded);
        anim.SetFloat("VerticalSpeed", rb.velocity.y);

        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, rb.velocity.y);
        rb.velocity = movement * speed;

        if(getVelocity() > 0.5)
        {
            if(transform.localScale.x > 0)
            {
                Flip();
            }
        }
        else if(getVelocity() < -0.5)
        {
            if(transform.localScale.x < 0)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public float getVelocity()
    {
        return rb.velocity.x;
    }
}
