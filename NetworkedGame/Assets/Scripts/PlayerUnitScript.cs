using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerUnitScript : NetworkBehaviour
{
    float h;
    public float hSpeed;
    Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasAuthority)
        {
            return;
        }

        h = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(h * hSpeed * Time.deltaTime, rb2D.velocity.y);
    }
}
