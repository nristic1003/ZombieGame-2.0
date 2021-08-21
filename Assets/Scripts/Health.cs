using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite hearth;


    private void Start()
    {
        for(int i=0;i<numOfHearts;i++)
        {
            hearts[i].sprite = hearth;
        }

    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<numOfHearts;i++)
        {
            hearts[i].enabled = true;
        }
    }
}
