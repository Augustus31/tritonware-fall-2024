using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyScript : EnemyAbstractScript
{
    public Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        room = 1;
        speed = 2;
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(openFire());
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = rb.position;
        (int, int) newCord = ((int)Math.Floor(position.x), (int)Math.Floor(position.y));
        rb.velocity = FindBestDirection(new int[16, 16], newCord, (14, 14)) * speed;
        Debug.Log(rb.velocity);
    }

    IEnumerator openFire()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, Mathf.Infinity, Physics2D.DefaultRaycastLayers, -0.5f, Mathf.Infinity);
            Debug.Log(hit.collider.gameObject);
            if (hit)
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    weapon.shoot(transform.position, player.transform.position);
                    yield return new WaitForSeconds(1 / weapon.fireRate + 0.02f);
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
