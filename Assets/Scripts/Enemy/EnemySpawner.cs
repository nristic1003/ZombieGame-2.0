using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject zombie;

    private float newX;
    public float timePassed;

    public Transform playerPosition;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= 5) timePassed = 5;
    }


    IEnumerator SpawnEnemy()
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


    }

}
