using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    // Start is called before the first frame update
    public Pistol() : base(1.5f, false, "Standard", "Pistol")
    {
        
    }
    public override void shoot(Vector3 gunPos, Vector3 mousePos)
    {
        if (!player.GetComponent<PlayerScript>().disabled)
        {
            GameObject bullet = GameObject.Instantiate(projectile, gunPos, Quaternion.identity);
            Debug.Log("new shrapnel made!");
            bullet.transform.Rotate(new Vector3(0, 0, Mathf.Atan2(mousePos.y - gunPos.y, mousePos.x - gunPos.x)));
            bullet.GetComponent<Projectile>().target = new Vector2(mousePos.x, mousePos.y); 
            bullet.GetComponent<Projectile>().owner = 0;
            player.GetComponent<PlayerScript>().disablerFunc(fireRate);
        }
        
    }
}
