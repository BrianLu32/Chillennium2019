using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour
{
    float time = 2;
    public float speed;
    bool hit = false;
    float baseSpeed = 5;
    public float hp = 10;
 
    void OnCollisionEnter2D(Collision2D touched)
    {
        if (touched.gameObject.name == "Enemy")
        {
            speed -= 1;
            hit = true;
            time = 2;
            hp -= 1;
        }

    }

    void Update()
    {
        
        if (hit)
        {
            time -= Time.deltaTime;
        }
        if (time <= 0)
        {
            speed = baseSpeed;
        }
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;
    }
}

