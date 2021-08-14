using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;

    private Transform myChild;

    public int dir;


    private void Awake()
    {
      myChild =  transform.GetChild(0);
    }

    private void Start()
    {
      
        StartCoroutine(ShoothingABullet());
    }


    IEnumerator ShoothingABullet()
    {
        yield return new WaitForSeconds(Random.RandomRange(1, 3));
        GameObject bull =  Instantiate(bullet, myChild.position, Quaternion.identity);
        bull.GetComponent<ShoothingABullet>().dirrection = dir;
        StartCoroutine(ShoothingABullet());
    }


}
