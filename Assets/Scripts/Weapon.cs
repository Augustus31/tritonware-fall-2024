using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon
{
    protected float fireRate;
    protected bool disabled;
    protected bool melee;
    protected GameObject projectile;
    public Weapon(float fireRate, bool melee, string projectile)
    {
        this.fireRate = fireRate;
        this.melee = melee;
        this.projectile = (GameObject)Resources.Load("Prefabs/" + projectile + "Projectile");
        disabled = false;
    }

    public abstract void shoot(Vector3 gunPos, Vector3 mousePos);

    public IEnumerator disabler()
    {
        disabled = true;
        yield return new WaitForSeconds(1 / fireRate);
        disabled = false;
    }

}
