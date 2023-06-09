using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float speed = 0.1f;
    public float health = 100;

   // public int worth = 100;
    public bool death = false;

    //public GameObject DeathEffect;

    [Header("Unity Stuff")]

    //public Image healBar;

    GameObject player;
    GameObject cameraLook;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraLook = GameObject.FindGameObjectWithTag("LookPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void Move()
    {
        if (player == null || cameraLook == null)
        {
            return;
        }
        transform.LookAt(cameraLook.transform.position);
        transform.position = Vector3.Lerp(transform.position, player.transform.position , speed * Time.deltaTime);
    }
}
