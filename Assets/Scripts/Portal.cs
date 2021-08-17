using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{


    public Transform destinationTeleport;
    public static float currentTeleport = 0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && currentTeleport==1f)
        {
            Portal.currentTeleport = 0f;
            StartCoroutine(Teleport());
        }
    }


    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1f);
        Vector3 newPosition = new Vector3(destinationTeleport.position.x, destinationTeleport.position.y + 1f, 0);
        GameObject.FindWithTag("Player").GetComponent<Player>().teleport(newPosition);
    }
}
