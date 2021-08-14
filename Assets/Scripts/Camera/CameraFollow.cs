using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{


    private Transform player;

    private Vector3 temp;

    private float minX = 0.30f;


    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player)
            return;

        temp = transform.position;
        transform.position = new Vector3(temp.x, player.position.y + 2.5f, temp.z);
        if (player.position.x > minX)
        {
            transform.position = new Vector3(player.position.x,transform.position.y, temp.z);
        }
       
    }
}
