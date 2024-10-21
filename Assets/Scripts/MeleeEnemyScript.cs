using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MeleeEnemyScript : EnemyAbstractScript
{
    // Start is called before the first frame update
    public override void Start()
    {
        room = 1;
        speed = 2;
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        Vector2 position = rb.position;
        (int, int) newCord = ((int)Math.Floor(position.x), (int)Math.Floor(position.y));
        rb.velocity = FindBestDirection(new int[16, 16], newCord, (14, 14)) * speed;
        base.Update();
    }
    /*
    private IEnumerator WaitForObject()
    {

        // Wait until the next frame
        yield return new WaitForSeconds(1.0f);
        // grid = GameObject.Find("Room").GetComponent<Room>().tiles;
        Debug.Log(FindBestDirection(new int[16, 16], (1, 1), (13, 13)));
        rb.velocity = FindBestDirection(new int[16, 16], (1, 1), (13, 13)) * speed;
        Debug.Log(rb.velocity);

        Debug.Log("The other object has been created and its Start() method has been called!");
    }
    */
}
