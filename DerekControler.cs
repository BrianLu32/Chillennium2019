using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DerekControler : MonoBehaviour {

    public float maxS = 11f;
    private bool right = false; //Prone to change

    private Animator anim;

    private bool ground = false;
    public Transform grCheck;
    private float grRadius = 0.2f;
    public float jForce = 5f;
    public LayerMask wiGround;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    void Update()
    {
        if(ground && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jForce));
        }
    }

    // Update is called once per frame
    void FixedUpdate () {

        ground = Physics2D.OverlapCircle(grCheck.position, grRadius, wiGround);
        anim.SetBool("Ground", ground);
        anim.SetFloat("VerticalSpeed", GetComponent<Rigidbody2D>().velocity.y);

        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxS, GetComponent<Rigidbody2D>().velocity.y);

        if(move > 0 && !right)
        {
            Flip();
        }
        else
        {
            if(move < 0 && right)
            {
                Flip();
            }
        }
	}

    void Flip()
    {
        right = !right;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
