using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            GameController.gameManager.GameOver();
        }
    }

}
