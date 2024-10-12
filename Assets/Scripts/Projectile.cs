using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Vector2 direction;
    public float lifeTime;
    public float damage;   
    private Rigidbody2D rb;
    public GameObject origin;

    public Projectile(Vector2 direction, GameObject origin, float speed = 10f, float lifeTime = 5f, float damage = 10f)
    {
        this.direction = direction;
        this.origin = origin;
        this.speed = speed; 
        this.lifeTime = lifeTime;
        this.damage = damage;   
    } 

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody2D>();
        
        // Move the projectile forward with specified speed
        rb.velocity = direction * speed; // Assuming the projectile is fired along the x-axis (right direction)

        // Destroy the projectile after 'lifetime' seconds
        Destroy(gameObject, lifeTime);
    }
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject != origin && (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * speed;    
    }
}
