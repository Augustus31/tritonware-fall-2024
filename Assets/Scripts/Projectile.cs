using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float damage;
    public int owner; //0 for player, 1 for enemy
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody2D>();

        // Destroy the projectile after 'lifetime' seconds
        Destroy(gameObject, lifeTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(owner == 0)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
                collision.gameObject.GetComponent<EnemyAbstractScript>().death();
            }
        }
        else if(owner == 1)
        {
            if (collision.gameObject.tag == "Player")
            {
                Destroy(gameObject);
                collision.gameObject.GetComponent<PlayerScript>().death();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
