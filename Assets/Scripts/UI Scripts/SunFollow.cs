using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFollow : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform maincamera;
    void Awake()
    {
        maincamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = maincamera.position.x -7.4f;
        temp.y = maincamera.position.y +3.889267f;
        
        transform.position = temp;
    }
}
