using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    public bool touchingPlatform;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingPlatform = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb.velocity;


        if (Input.GetKeyDown(KeyCode.Space) && (touchingPlatform == true))
        {
            vel.y = 20;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            vel.y = -20;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //rb.velocity = new Vector2(-10, 0);
            vel.x = -20;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //rb.velocity = new Vector2(10, 0);
            vel.x = 20;
        }


        rb.velocity = vel; 
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            touchingPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            touchingPlatform = false;
        }
    }
}