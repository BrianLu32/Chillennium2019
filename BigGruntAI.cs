using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGruntAI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public float speed;
    public int hp;
    void OnCollisionEnter2D(Collision2D touched)
    {
        if (touched.gameObject.name == "bullet")
        {
            hp -= 1;
        }
        if (touched.gameObject.name == "Main")
        {
            Vector3 pos = transform.position;
            var MainPos = new Vector3(target.transform.position.x, target.transform.position.y, 0);
            var moveEnemy = MainPos - pos;
            transform.position += moveEnemy * speed * -Time.deltaTime * 10;
        }


    }
    // Update is called once per frame

    void Update()
    {

        Vector3 pos = transform.position;
        var MainPos = new Vector3(target.transform.position.x, target.transform.position.y, 0);
        var moveEnemy = MainPos - pos;
        transform.position += moveEnemy * speed * Time.deltaTime;


    }

}
