using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float moveSpeed = 20f;
    public GameObject boomEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * moveSpeed, Space.World);
    }

    private void OnCollisionEnter(Collision other)
    {

        Destroy(gameObject);
        Instantiate(boomEffect, transform.position, Quaternion.identity);
        
    }
}
