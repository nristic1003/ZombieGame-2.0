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
        StartCoroutine(ShoothingABullet()); //pocetni poziv funkcije ShoothingABullet prilkom kreiranja objekta
    }

    IEnumerator ShoothingABullet() //deo koda koji rai kao posebna nit
    {
        yield return new WaitForSeconds(Random.RandomRange(1, 3));// nakon koliko vremena se poziva ova fukcija ponovo [1,3] sekundi
        GameObject bull =  Instantiate(bullet, myChild.position, Quaternion.identity); //kreiranje objekta metka
        bull.GetComponent<ShoothingABullet>().dirrection = dir; //podesavanje smera metka
        bull.GetComponent<ShoothingABullet>().setScale(transform.localScale); //podesavanje velicina metka
        StartCoroutine(ShoothingABullet()); //ponovni poziv funkcije, (ne kreira se rekurzija)
    }


}
