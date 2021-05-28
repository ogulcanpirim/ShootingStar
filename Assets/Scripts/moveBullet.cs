using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBullet : MonoBehaviour
{

    public float bulletForce;


    void Start()
    {
        bulletForce = 10f;
    }

    void FixedUpdate()
    {
        this.GetComponent<Rigidbody2D>().velocity = (Vector2.up * bulletForce);
    }

    
}
