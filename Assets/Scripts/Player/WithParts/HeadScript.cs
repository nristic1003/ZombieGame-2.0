using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScript : MonoBehaviour
{
    private Rigidbody2D myHead;

    private float force = 10f;

    private GameObject parr;

    bool flag = false;


    void Start()
    {
        
    }

    public void ThrowHead(GameObject head)
    {
        myHead = GetComponent<Rigidbody2D>();
        head.transform.position= new Vector3(1, 1, 0);
        flag = true;
        Debug.Log(transform.position);
    }

    private void FixedUpdate()
    {
        if(flag)
             myHead.AddForce(new Vector2(2f, 8f), ForceMode2D.Impulse);
    }


}
