using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2AI : MonoBehaviour
{
    public double time = 60;
    public GameObject barrel;
    public GameObject barre2;
    public GameObject grunt;
    bool buffer = true;
    Vector3 b1;
    public Vector3 b2;
    public Vector3 b3;
    Vector3 bs1;
    Vector3 bs2;
    Vector3 bs3;
    Vector3 g1;
    Vector3 g2;
    double walk = .05;
    // Start is called before the first frame update
    
    void Awake()
    {
        b1 = new Vector3(transform.position.x, transform.position.y, 0);
        b2 = new Vector3(transform.position.x, transform.position.y + (float)1.65, 0);
        b3 = new Vector3(transform.position.x, transform.position.y - (float)1.65, 0);
        bs1 = new Vector3(transform.position.x - 1, transform.position.y, 0);
        bs2 = new Vector3(transform.position.x - 1, transform.position.y + 2, 0);
        bs3 = new Vector3(transform.position.x - 1, transform.position.y - 2, 0);
        g1 = new Vector3(transform.position.x - 3, transform.position.y + 3, 0);
        g2 = new Vector3(transform.position.x - 3, transform.position.y - 3, 0);

    }
    // Update is called once per frame
    void Update()
    {
        
      time -= Time.deltaTime;
        if (time <= 60 && time > 55 && buffer == true) // spawn mid
        {
             transform.position = Vector3.MoveTowards(transform.position, b1, (float)walk);
            if (transform.position == b1)
            {
                //spawn b1
                b1 = new Vector3(transform.position.x, transform.position.y, 0);
                Instantiate(barre2, bs1, Quaternion.identity);
                //spawn grunt
                Instantiate(grunt, g1, Quaternion.identity);
                Instantiate(grunt, g2, Quaternion.identity);
                buffer = false;
            }
        }
        if(time <= 55 && time > 50 && buffer == false) // spawn top
        {
            transform.position = Vector3.MoveTowards(transform.position, b2, (float)walk);
            if(transform.position == b2)
            {
                //spawn b2
                Instantiate(barre2, bs2, Quaternion.identity);
                //spawn grunt
                Instantiate(grunt, g1, Quaternion.identity);
                //Instantiate(grunt, g2, Quaternion.identity);
                buffer = true;
            }
           
        }
        if(time <= 50 && time > 45 && buffer == true) // spawn bottom
        {
            transform.position = Vector3.MoveTowards(transform.position, b3, (float)walk);
            if (transform.position == b3)
            {
                //spawn b3
                Instantiate(barre2, bs3, Quaternion.identity);
                //spawn grunt
                //Instantiate(grunt, g1, Quaternion.identity);
                Instantiate(grunt, g2, Quaternion.identity);
                buffer = false;
            }
            
        }
        if (time <= 45 && time > 40 && buffer == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, b2, (float)walk);
            if (transform.position == b2)
            {
                //spawn b2
                //transform.position = Vector3.MoveTowards(transform.position, bs2, 1);
                //spawn grunt
                Instantiate(barrel, bs2, Quaternion.identity);
                Instantiate(grunt, g2, Quaternion.identity);
                //transform.position = Vector3.MoveTowards(transform.position, b2, 1);
                buffer = true;
            }
            


        }
        if (time <= 40 && time > 35 && buffer == true)
        {
            Instantiate(barre2, bs2, Quaternion.identity);
            buffer = false;
        }
        if (time <= 35 && time > 30 && buffer == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, b3, (float)walk);
            if (transform.position == b3)
            {
                //spawn b2
                //transform.position = Vector3.MoveTowards(transform.position, bs2, 1);
                //spawn grunt
                Instantiate(barrel, bs3, Quaternion.identity);
                Instantiate(grunt, g1, Quaternion.identity);
                buffer = true;
            }
        }
        if (time <= 30 && time > 25 && buffer == true)
        {
            Instantiate(barre2, bs3, Quaternion.identity);
            buffer = false; 
        }
        if (time <= 25 && time > 20 && buffer == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, b1, (float)walk);
            if (transform.position == b1)
            {
                
                Instantiate(barrel, bs1, Quaternion.identity);
                Instantiate(barrel, bs2, Quaternion.identity);
                Instantiate(barrel, bs3, Quaternion.identity);
                buffer = true;
                time = 5;
            }
        }
        if (time <= 0)
        {
            time = 60;
            buffer = true;
        }        
    }
}
