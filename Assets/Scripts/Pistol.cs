using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    // Start is called before the first frame update
    public Pistol() : base(2f, false, "Standard")
    {
        
    }
    public override void shoot(Vector3 gunPos, Vector3 mousePos)
    {
        GameObject bullet = GameObject.Instantiate(projectile, gunPos, Quaternion.identity);
        bullet.transform.Rotate(new Vector3(0, 0, Mathf.Atan2(mousePos.y - gunPos.y, mousePos.x - gunPos.x)));
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2((mousePos - gunPos).x, (mousePos - gunPos).y).normalized * bullet.GetComponent<Projectile>().speed;
        bullet.GetComponent<Projectile>().owner = 0;
    }
}
