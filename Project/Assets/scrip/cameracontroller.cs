using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public float senvity = 100f;
    public Transform player;
    Vector3 pos;
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * senvity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * senvity * Time.deltaTime;

        //pos.x = Mathf.Clamp(mouseX, 19f, -19f);
        player.Rotate(Vector3.up * mouseX);
        //pos.y = Mathf.Clamp(pos.y, 19f, -19f);

        //transform.position = new Vector3(pos.x, pos.y, 0.0f);
    }
}
