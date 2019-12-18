using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerUnitScript : NetworkBehaviour
{
    float h;
    float v;
    public float hSpeed;
    //Rigidbody2D rb2D;

    void Start()
    {
        //rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasAuthority)
        {
            return;
        }

        h = Input.GetAxisRaw("Horizontal");

        transform.Translate(new Vector3(h * hSpeed * Time.deltaTime, 0, 0));

        if (h > 0)
        {
            transform.localScale = new Vector3 (1, 1, 1);
        }
        else if (h < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    /*
    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(h * hSpeed * Time.deltaTime, rb2D.velocity.y);
    }*/
}
