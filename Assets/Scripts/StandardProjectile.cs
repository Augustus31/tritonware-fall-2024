using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardProjectile : Projectile
{

    // Start is called before the first frame update
    public override void Start()
    {
        speed = 15;
        lifeTime = 3;
        damage = 10;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
