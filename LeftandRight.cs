using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftandRight : MonoBehaviour {

    public Animator anim;
    public Control cont;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
		if(cont.getVelocity() > 0.5 || cont.getVelocity() < -0.5)
        {
            anim.SetBool("IsMoving", true);
        }
        if(cont.getVelocity() == 0)
        {
            anim.SetBool("IsMoving", false);
        }
	}
}
