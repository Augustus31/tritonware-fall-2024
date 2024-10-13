using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon
{
    protected float fireRate;
    protected bool melee;
    protected GameObject projectile;
    protected GameObject player;
    public Weapon(float fireRate, bool melee, string projectile)
    {
        this.fireRate = fireRate;
        this.melee = melee;
        this.projectile = (GameObject)Resources.Load("Prefabs/" + projectile + "Projectile");
        player = GameObject.Find("Player");
    }

    public abstract void shoot(Vector3 gunPos, Vector3 mousePos);

}
