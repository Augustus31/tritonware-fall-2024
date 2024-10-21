using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponObjectScript : MonoBehaviour
{
    private GameObject player;
    public float distance;
    private Weapon weapon1;
    private Weapon weapon2;
    private SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        weapon1 = new ShrapnelGun();
        weapon2 = new Shotgun();
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = weapon1.getSprite();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.rotation = Quaternion.identity;
        float rot = 180 * Mathf.Atan2(mousePos.y - player.transform.position.y, mousePos.x - player.transform.position.x) / Mathf.PI;
        gameObject.transform.Rotate(new Vector3(0, 0, rot));
        transform.position = new Vector3((mousePos - player.transform.position).x, (mousePos - player.transform.position).y, 0).normalized * distance + player.transform.position;

        Debug.Log(rot);
        if(rot > 90 || rot < -90)
        {
            rend.flipY = true;
        }
        else
        {
            rend.flipY = false;
        }

        if (Input.GetMouseButton(((int)MouseButton.LeftMouse)))
        {
            weapon1.shoot(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(weapon2 != null){
                (weapon1, weapon2) = (weapon2, weapon1);
                rend.sprite = weapon1.getSprite();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerScript ps = player.GetComponent<PlayerScript>();
            if (ps.collectible)
            {
                if(ps.collectibleObj.GetComponent<CollectibleAbstractScript>().type == "weapon")
                {
                    if(weapon2 != null)
                    {
                        (ps.collectibleObj.GetComponent<CollectibleWeaponScript>().weapon, weapon1) = (weapon1, ps.collectibleObj.GetComponent<CollectibleWeaponScript>().weapon);
                        rend.sprite = weapon1.getSprite();
                        ps.collectibleObj.GetComponent<CollectibleWeaponScript>().updateSprite();
                    }
                    else
                    {
                        weapon2 = ps.collectibleObj.GetComponent<CollectibleWeaponScript>().weapon;
                        GameObject.Destroy(ps.collectibleObj);
                        ps.collectibleObj = null;
                        ps.collectible = false;
                    }
                }
            }
        }
    }
}
