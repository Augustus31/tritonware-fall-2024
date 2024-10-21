using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Weapon
{
    // Start is called before the first frame update
    public Bomb() : base(1.5f, false, "Standard", "Pistol")
    {

    }
    public override void shoot(Vector3 gunPos, Vector3 mousePos)
    {
        GameObject bullet = GameObject.Instantiate(projectile, gunPos, Quaternion.identity);
        bullet.transform.Rotate(new Vector3(0, 0, Mathf.Atan2(mousePos.y - gunPos.y, mousePos.x - gunPos.x)));
        bullet.GetComponent<Projectile>().target = new Vector2(mousePos.x, mousePos.y);
        bullet.GetComponent<Projectile>().owner = 0;

    }
}
