using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    double speed = .05;
    float time = 0;
    int hp = 10;
    void OnCollisionEnter2D(Collision2D touched)
    {
        if (touched.gameObject.name == "bullet")
        {

            speed = .04;
            hp -= 1;
            time = 1;
          
        }
        if (touched.gameObject.name == "Main")
        {
            Vector3 pos = transform.position;
            var MainPos = new Vector3(target.transform.position.x, target.transform.position.y, 0);
            var moveEnemy = MainPos - pos;
            transform.position += moveEnemy * (float)6 * -Time.deltaTime*30;
            //transform.position = Vector3.MoveTowards(pos, MainPos, -(float).5);
        }
       

    }
    // Update is called once per frame

    void Update()
    {
        if (hp == 0)
        {
            Destroy(this.gameObject);
        }
       if(this.gameObject.name == "grunt(Clone)")
        {
            if(time == 1)
            {
                time -= Time.deltaTime;
            }
            if (time < 0)
            {
                time = 0;
            }
            var pos = new Vector3(transform.position.x, transform.position.y, 0);
            var MainPos = new Vector3(target.transform.position.x, target.transform.position.y, 0);
            var moveEnemy = MainPos - pos;
            //transform.position += moveEnemy * speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(pos, MainPos, (float)speed);
            transform.up = moveEnemy * -(float).5;
        }
        
    }
   
}
