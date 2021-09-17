using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTestera : MonoBehaviour
{
    public float sawSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(sawSpeed * Time.deltaTime,0,0);
    }
}
