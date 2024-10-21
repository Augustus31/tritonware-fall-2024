using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrapnelGun : Weapon
{
    public ShrapnelGun() : base(0.6f, false, "Explosive", "Shrapnel")
    {

    }
    public override void shoot(Vector3 gunPos, Vector3 mousePos)
    {
        if (!player.GetComponent<PlayerScript>().disabled)
        {
            GameObject bullet = GameObject.Instantiate(projectile, gunPos, Quaternion.identity);
            bullet.transform.Rotate(new Vector3(0, 0, Mathf.Atan2(mousePos.y - gunPos.y, mousePos.x - gunPos.x)));
            bullet.GetComponent<Projectile>().target = new Vector2(mousePos.x, mousePos.y);
            bullet.GetComponent<Projectile>().owner = 0;
            player.GetComponent<PlayerScript>().disablerFunc(fireRate);
        }

    }
}
