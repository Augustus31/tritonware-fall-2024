using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Weapon weapon1;
    private Weapon weapon2;
    public bool disabled;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
        weapon1 = new Shotgun();
        disabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, 0);

        //on key press (movement)
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(rb.velocity.x - 1, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(rb.velocity.x + 1, rb.velocity.y);
        }

        if (Input.GetMouseButton(((int)MouseButton.LeftMouse)))
        {
            weapon1.shoot(GameObject.Find("Weapon").transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

        rb.velocity = rb.velocity.normalized * speed;
    }

    public void death()
    {
        GameControllerScript.GC.restartLevel();
    }

    public void disablerFunc(float fireRate)
    {
        StartCoroutine(disabler(fireRate));
    }

    private IEnumerator disabler(float fireRate)
    {
        disabled = true;
        yield return new WaitForSeconds(1 / fireRate);
        disabled = false;
    }
}
