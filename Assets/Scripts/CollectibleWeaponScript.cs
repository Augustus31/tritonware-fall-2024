using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleWeaponScript : CollectibleAbstractScript
{
    public Weapon weapon;
    // Start is called before the first frame update
    public override void Start()
    {
        type = "weapon";
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        rend.sprite = weapon.getSprite();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
    }

    public void updateSprite()
    {
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        rend.sprite = weapon.getSprite();
    }
}
