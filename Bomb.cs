using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
   /* void OnCollisionEnter2D(Collision2D touched)
    {
        if (touched.gameObject.name == "Main")
        {
            Destroy(this.gameObject);
        }
    }*/
    double time = .1;
    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.name == "Bomb(Clone)")
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        
    }
}
