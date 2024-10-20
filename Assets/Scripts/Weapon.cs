using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon
{
    public float fireRate;
    protected bool melee;
    protected GameObject projectile;
    protected GameObject player;
    protected Sprite sprite;
    public Weapon(float fireRate, bool melee, string projectile, string sprite)
    {
        this.fireRate = fireRate;
        this.melee = melee;
        this.projectile = (GameObject)Resources.Load("Prefabs/" + projectile + "Projectile");
        this.sprite = Resources.Load<Sprite>("Sprites/" + sprite);
        Debug.Log(this.sprite.ToString());
        player = GameObject.Find("Player");
    }

    public abstract void shoot(Vector3 gunPos, Vector3 mousePos);

    public Sprite getSprite()
    {
        return sprite;
    }

}
