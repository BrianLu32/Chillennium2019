using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerAI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public float speed;
    void OnCollisionEnter2D(Collision2D touched)
    {
        if (touched.gameObject.name == "bullet")
        {
            Destroy(this.gameObject);
        }
        if (touched.gameObject.name == "Main")
        {
            Vector3 pos = transform.position;
            var MainPos = new Vector3(target.transform.position.x, target.transform.position.y, 0);
            var moveEnemy = MainPos - pos;
            transform.position += moveEnemy * speed * -Time.deltaTime * 30;
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
