using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Transform parrent = transform.parent;
            Transform child = transform.GetChild(0);

            Vector3 newPosition = new Vector3(transform.position.x + child.localPosition.x,  child.position.y + 1f, 0);
            GameObject.FindWithTag("Player").GetComponent<Player>().teleport(newPosition);
        }
    }
}
