using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyScript : EnemyAbstractScript
{
    // Start is called before the first frame update
    void Start()
    {
        room = 1;
        speed = 2;
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = (player.transform.position - transform.position).normalized * speed;
    }
}
