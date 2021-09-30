using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;
    private bool moveRight;
    public bool moveUpDown = false;

    Vector3 nextPos;


    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!moveUpDown)
        {
            if (transform.position.x <= pos1.position.x)
            {
                nextPos = pos2.position;

            }
            if (transform.position.x >= pos2.position.x)
            {
                nextPos = pos1.position;
            }
        }
        else
        {
           if (transform.position.y <= pos1.position.y) //provera da li je trenutna pozicija platforme <=krajnjoj poziciji platforme
            {
                nextPos = pos2.position; //pozicija do koje treba doći
            }
            if (transform.position.y>= pos2.position.y)
            {
                nextPos = pos1.position;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(nextPos.x, nextPos.y, 0) , speed * Time.deltaTime); 
                //funkcija koja menja poziciju platforme ka datoj poziciji odredjenom brzinom

    }

    

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }


}
