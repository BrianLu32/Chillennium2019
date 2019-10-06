using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelAI : MonoBehaviour
{
    //double time = 10;
    Vector3 direction;
   
    double speed = .75;
    
    // Update is called once per fram
    void Awake()
    {
        direction = new Vector3(transform.position.x - 5, transform.position.y, 0);

    }
    void Update()
    {
        //time -= Time.deltaTime;
        if (this.gameObject.name == "barrel1(Clone)")
        {
            
                transform.position = Vector3.MoveTowards(transform.position, direction, (float)speed);
            

            //}
            if (transform.position == direction)
            {
                // Instantiate(bom, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }


    }

}
