using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleAbstractScript : MonoBehaviour
{
    public string type;
    public Sprite sprite;
    protected GameObject player;

    // Start is called before the first frame update
    public virtual void Start()
    {
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        rend.sprite = sprite;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            PlayerScript ps = player.GetComponent<PlayerScript>();
            ps.collectible = true;
            ps.collectibleObj = this.gameObject;
            Debug.Log("entered!");
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            PlayerScript ps = player.GetComponent<PlayerScript>();
            ps.collectible = false;
            ps.collectibleObj = null;
            Debug.Log("exited!");
        }
    }

}
