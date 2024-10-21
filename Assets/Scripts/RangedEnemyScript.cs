using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyScript : EnemyAbstractScript
{
    public Weapon weapon;
    // Start is called before the first frame update
    public override void Start()
    {
        room = 1;
        speed = 1;
        base.Start();
        StartCoroutine(openFire());
    }

    // Update is called once per frame
    public override void Update()
    {
        Vector2 position = rb.position;
        (int, int) newCord = ((int)Math.Floor(position.x), (int)Math.Floor(position.y));
        rb.velocity = FindBestDirection(new int[16, 16], newCord, (14, 14)) * speed;
        base.Update();
    }

    IEnumerator openFire()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, Mathf.Infinity, Physics2D.DefaultRaycastLayers, -0.5f, Mathf.Infinity);
            if (hit)
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    weapon.shoot(transform.position, player.transform.position);
                    yield return new WaitForSeconds((1 / weapon.fireRate) * 2);
                }
                else
                {
                    yield return new WaitForEndOfFrame();
                }
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }
        }
        

    }
}
