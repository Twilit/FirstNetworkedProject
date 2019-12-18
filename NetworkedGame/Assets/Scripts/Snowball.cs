using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Snowball : NetworkBehaviour
{
    float size;
    float fallSpeed;
    float spinSpeed;

    void Start()
    {
        size = Random.Range(3, 6);
        fallSpeed = Random.Range(5, 10);
        spinSpeed = Random.Range(3, 8);

        transform.localScale = Vector3.one * size;
    }

    void Update()
    {
        transform.Translate(new Vector3(0, -fallSpeed * Time.deltaTime, 0));

        transform.GetChild(0).Rotate(Vector3.right * -spinSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            NetworkServer.Destroy(collision.gameObject);
        }
        else if (collision.tag == "Ground")
        {
            NetworkServer.Destroy(gameObject);
        }
    }
}
