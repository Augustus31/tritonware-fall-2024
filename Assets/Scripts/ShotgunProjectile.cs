using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunProjectile : Projectile
{

    // Start is called before the first frame update
    public override void Start()
    {
        speed = 10f;
        lifeTime = .5f;
        damage = 5f;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
