using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelShield : MonoBehaviour
{

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D touched)
    {
        if (touched.gameObject.name == "barrel1(Clone)" || touched.gameObject.name == "barrel1")
        {
            Destroy(this.gameObject);
        }
    }
   void Update()
    {

    }
    
}
