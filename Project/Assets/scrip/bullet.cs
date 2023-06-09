using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float time = 2;
    public float dame = 50;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, time);
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<move>().health-=dame;

            Destroy(this.gameObject);
        }
    }
}
