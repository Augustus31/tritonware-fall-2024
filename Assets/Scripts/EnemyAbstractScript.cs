using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstractScript : MonoBehaviour
{
    public int room;
    public int speed;
    protected GameObject player;
    protected Rigidbody2D rb;

    void death()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().death();
        }
    }
}
