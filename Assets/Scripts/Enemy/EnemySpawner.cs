using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject zombie;

    private float newX;
    public float timePassed;
    public float offsetDistance;
    public Transform playerPosition;

    void Start()
    {
     /*   StartCoroutine(SpawnEnemy());*/
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= 5) timePassed = 5;
    }


    private void spawnEnemy()
    {
        playerPosition = GameObject.FindWithTag("Player").transform;
        Vector3 spawnPosition = new Vector3(playerPosition.position.x + offsetDistance, transform.position.y + 0.5f, transform.position.z);
        Instantiate(zombie, spawnPosition, Quaternion.identity);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            spawnEnemy();
            Destroy(gameObject);
        }
    }

    /*    IEnumerator SpawnEnemy()
        {
            yield return new WaitForSeconds(Random.Range(2, 7 - timePassed));

            playerPosition = GameObject.FindWithTag("Player").transform;

            newX = Random.Range(-7, 24);
            if (Mathf.Abs(playerPosition.position.x - newX) < 1)
                if (newX < 0) newX++;
                else newX--;
            transform.position = new Vector3(newX, transform.position.y +0.5f, transform.position.z);
            Instantiate(zombie, transform.position, Quaternion.identity);
            StartCoroutine(SpawnEnemy());


        }*/

}
