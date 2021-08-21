using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int health = 100;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0) 
        { 

            Destroy(gameObject);
            GameController.gameManager.GameOver();
        }
    }


    public void TakeDamage(int damage)
    {

        if (health - damage <= 0) health = 0;
        else
            health -= damage;
        GameController.gameManager.setHealth(health);
    }

    public void teleport(Vector3 newPosition)
    {
        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }

  

}
