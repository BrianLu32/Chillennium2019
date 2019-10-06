using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stunBullet : MonoBehaviour
{
    public GameObject target;
    public GameObject bom;
    // Start is called before the first frame update
    Vector3 direction;
    public Rigidbody2D rb;
    float speed = 30;
    void OnCollisionEnter2D(Collision2D touched)
    {
        if (touched.gameObject.name == "Main")
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per fram
    void Awake()
    {
        direction = new Vector3(target.transform.position.x, target.transform.position.y, 0);
       
    }
    void Update()
        {

        if (this.gameObject.name == "stun(Clone)")
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, direction, step);
        }
        if(transform.position == direction)
        {
            Instantiate(bom, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
       
       
    }
  
}
