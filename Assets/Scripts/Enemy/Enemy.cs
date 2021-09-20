

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Enemy : MonoBehaviour
{
    public int health;

    public GameObject effect, enemyHit, coin, newBullets;

    private AudioSource source;
    public AudioClip clip;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (health <= 0)
        {
            int chance = Random.Range(1, 11);
            if(chance <= 3)
            {
                Instantiate(newBullets, transform.position, Quaternion.identity);
            }
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(coin, transform.position, Quaternion.identity);
            GameController.gameManager.setScore(1);
            Destroy(gameObject);
            CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);

        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(enemyHit, transform.position, Quaternion.identity);
        Debug.Log("Damage taken");
    }
}
