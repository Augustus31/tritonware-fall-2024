using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    protected Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //on key press (movement)
        if (Input.GetKeyDown(KeyCode.W))
        {
            velocity.y += 1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            velocity.x -= 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            velocity.y -= 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            velocity.x += 1;
        }

        //on key release (end movement)
        if (Input.GetKeyUp(KeyCode.W))
        {
            velocity.y -= 1;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            velocity.x += 1;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            velocity.y += 1;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            velocity.x -= 1;
        }

        //add velocity to position
        transform.position += velocity.normalized * speed * Time.deltaTime;
    }

}
