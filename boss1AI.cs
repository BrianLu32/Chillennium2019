using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1AI : MonoBehaviour
{
    public GameObject stuns;
    public GameObject grunt;
    float time = 2;
    public float hp = 10;
    public GameObject stunP;
    Vector3 spawn1;
    Vector3 spawn2;

    // Start is called before the first frame update

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D touched)
    {
        if (touched.gameObject.name == "bullet")
        {
            hp -= 1;
        }
    }
        void Awake()
    {
        spawn1 = new Vector3(transform.position.x - 2, transform.position.y + 1, 0);
        spawn2 = new Vector3(transform.position.x - 2, transform.position.y + 1, 0);
    }
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Instantiate(stuns,stunP.transform.position, Quaternion.identity);
            //stuns.transform = this.transform;
            time = 2;

           Instantiate(grunt, spawn1 , Quaternion.identity);
           Instantiate(grunt, spawn2, Quaternion.identity);

        }
    }
}
