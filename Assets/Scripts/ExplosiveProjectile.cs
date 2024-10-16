using System.Collections;
using UnityEngine;

public class ExplodingProjectile : Projectile
{
    public float explosionRadius = 5f; // Radius of explosion
    public LayerMask damageableLayer;  // Layer mask for objects that can be damaged

    // Override the Start method from Projectile to start with movement
    public override void Start()
    {
        speed = 5f;    // Set speed of the projectile
        lifeTime = 2f;  // Set the lifetime before explosion
        base.Start();   // Call the base class to handle movement

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
        // Log explosion event (for debugging)
        Debug.Log("Projectile exploded!");

        // Get all colliders within the explosion radius that are in the damageable layer
        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(transform.position, explosionRadius, damageableLayer);

        // Iterate through the objects and apply damage or effects
        foreach (Collider2D obj in objectsInRange)
        {
            if (obj.CompareTag("Enemy")) // If it's an enemy, apply damage
            {
                // Example: Apply damage to the enemy (assuming the enemy has a health component)
                EnemyAbstractScript enemy = obj.GetComponent<EnemyAbstractScript>();
                if (enemy != null)
                {
                    enemy.death();
                    // Call the TakeDamage method with the projectile's damage
                }
            }
        }

        // Destroy the projectile object after the explosion
        Destroy(gameObject);
    }

    // Optional: Visualize the explosion radius in the Scene view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    // Override OnTriggerEnter2D for handling direct hits before explosion
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (owner == 0 && collision.gameObject.CompareTag("Enemy")) // Direct hit by player projectile
        {
            Explode(); // Trigger explosion on direct hit
        }
    }
}