using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public bool disabled;
    public bool collectible;
    public GameObject collectibleObj;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
        disabled = false;
        collectible = false;
        collectibleObj = null;
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
