using System.Collections;
using UnityEngine;

public class ExplosiveProjectile : Projectile
{

    // Override the Start method from Projectile to start with movement
    public override void Start()
    {
        speed = 15f;    // Set speed of the projectile
        lifeTime = 0.7f;  // Set the lifetime before explosion
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = (target - new Vector2(transform.position.x, transform.position.y)).normalized * speed;

        // Start a coroutine to handle the explosion after lifetime
        StartCoroutine(ExplodeAfterTime(lifeTime));
    }

    // Coroutine that waits for the lifetime to pass, then triggers the explosion
    private IEnumerator ExplodeAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for lifetime duration
        Explode();
    }

    // Method to handle the explosion
    private void Explode()
    {
        Bomb bomb = new Bomb();
        for(int i = 0; i < 10; i++)
        {
            float rand = Random.Range(0, 2*Mathf.PI);
            Debug.Log(rand);
            bomb.shoot(transform.position, transform.position + new Vector3(Mathf.Cos(rand), Mathf.Sin(rand), 0));
        }
        
        Destroy(gameObject);
    }
}