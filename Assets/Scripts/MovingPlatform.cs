using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform posStart, posEnd;
    public float speed;
    private bool moveRight;

    Vector3 nextPos;


    void Start()
    {
        nextPos = posStart.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= posStart.position.x)
        {
            moveRight = true;

        }
        else if(transform.position.x >= posEnd.position.x)
        {
            moveRight = false;
        }
        if(moveRight)
         transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

    }


}
