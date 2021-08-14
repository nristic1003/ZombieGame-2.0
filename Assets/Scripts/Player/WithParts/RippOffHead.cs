using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippOffHead : MonoBehaviour
{
    public GameObject head, newHead;
    private bool rippedOff = false;
    private Animator anim;

    private Transform PreviousHeadPossition;


    void Start()
    {
        anim = GetComponent<Animator>();
        head = GameObject.FindWithTag("head");
        PreviousHeadPossition = head.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !rippedOff)
        {
            rippedOff = true;
            anim.SetBool("headDown" , true);
            Vector3 p = head.transform.position;
            p.x = p.x + 1f;
            Debug.Log(head.transform.position);
            //Instantiate(newHead, PreviousHeadPossition.position, Quaternion.identity);
            //head.SetActive(false);
            head.transform.position = new Vector3(1, 1, 0);
            head.transform.parent = null;
            head.AddComponent<Rigidbody2D>();
          

 
        }

        throwHead();
      

    }

    void throwHead()
    {
        if (Input.GetKey(KeyCode.Mouse1) && rippedOff)
        {
           transform.position = new Vector3(1, 1, 0);
            GameObject.FindWithTag("head").GetComponent<HeadScript>().ThrowHead(head);
        }
    }

}
