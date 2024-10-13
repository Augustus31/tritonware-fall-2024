using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObjectScript : MonoBehaviour
{
    private GameObject player;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.Rotate(new Vector3(0, 0, 180*Mathf.Atan2(mousePos.y - player.transform.position.y, mousePos.x - player.transform.position.x)/Mathf.PI));
        transform.position = new Vector3((mousePos - player.transform.position).x, (mousePos - player.transform.position).y, 0).normalized * distance + player.transform.position;
    }
}
