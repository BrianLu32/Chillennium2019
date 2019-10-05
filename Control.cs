using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Control : MonoBehaviour
{
    public float speed;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private float dashCooldown;
    private float nextDash;
    public Rigidbody2D rb;

    private Animation anim;
    public GameObject dashEffect;


    // Start is called before the first frame update
    void Start()
    {
        dashTime = startDashTime;
        dashCooldown = 2.0f;
        nextDash = 0.0f;
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * speed;

        if(CollisionDetect.Hit == true)
        {
            transform.Translate((CollisionDetect.Wall.x) / 1000, 0, (CollisionDetect.Wall.z) / 1000, Space.World);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(dashTime <= 0)
            {
                dashTime = startDashTime;
                rb.velocity = movement * speed;
                Instantiate(dashEffect, transform.position, Quaternion.identity);
            }
            else if(Time.time > nextDash)
            {
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                //anim.Play("Dash");
                dashTime -= Time.deltaTime;
                rb.velocity = movement * dashSpeed;
                nextDash = Time.time + dashCooldown;
            }
        }
    }

    private float getVelocityX()
    {
        return rb.velocity.x;
    }
    private float getVelocityY()
    {
        return rb.velocity.y;
    }
}
