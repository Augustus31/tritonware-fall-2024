using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardProjectile : Projectile
{
    // Start is called before the first frame update
    void Start()
    {
        speed = 15;
        lifeTime = 3;
        damage = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
