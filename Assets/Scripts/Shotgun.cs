using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{   
    private int numPellets;
    private float spreadAngle;
    // Start is called before the first frame update
    public Shotgun(float firerate = .5f, int numPellets = 5, float spreadAngle = 15f) : base(firerate, false, "Standard")
    {
        this.numPellets = numPellets;
        this.spreadAngle = spreadAngle;
    }
    public override void shoot(Vector3 gunPos, Vector3 mousePos)
    {
        if (!player.GetComponent<PlayerScript>().disabled)
        {
            // Calculate the direction from gun position to mouse position
            Vector2 baseDirection = (mousePos - gunPos).normalized;

            // Fire multiple pellets
            for (int i = 0; i < numPellets; i++)
            {
                // Calculate the spread for each pellet
                float angleOffset = Random.Range(-spreadAngle / 2, spreadAngle / 2);
                Vector2 spreadDirection = Quaternion.Euler(0, 0, angleOffset) * baseDirection;

                // Instantiate the pellet (bullet) at gun position
                GameObject pellet = GameObject.Instantiate(projectile, gunPos, Quaternion.identity);
                
                // Rotate the pellet to face the direction it's moving in
                float angle = Mathf.Atan2(spreadDirection.y, spreadDirection.x) * Mathf.Rad2Deg;
                pellet.transform.rotation = Quaternion.Euler(0, 0, angle);

                // Assign target and owner to the pellet (if applicable)
                Projectile pelletProjectile = pellet.GetComponent<Projectile>();
                if (pelletProjectile != null)
                {
                    pelletProjectile.target = gunPos + (Vector3)spreadDirection * 100f; // Target far in the direction of the pellet
                    pelletProjectile.owner = 0; // Example owner ID for player
                }

            }
        
            player.GetComponent<PlayerScript>().disablerFunc(fireRate);
        }
        
    }
}