using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] Sprite springInSprite;
    [SerializeField] Sprite springOutSprite;
    [SerializeField] float force = 10.0f;

    SpriteRenderer sprRenderer;
    float springOutTimeLeft = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
        sprRenderer.sprite = springInSprite;
    }

    void Update()
    {
        if(springOutTimeLeft > 0)
        {
            springOutTimeLeft -= Time.deltaTime;

            if(springOutTimeLeft <= 0)
            {
                sprRenderer.sprite = springInSprite;
                springOutTimeLeft = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(springOutTimeLeft > 0)
        {
            return;
        }

        GameObject gameObj = coll.gameObject;
        if(gameObj.tag == "Player")
        {
            Rigidbody2D playerBody = gameObj.GetComponent<Rigidbody2D>();
            if(playerBody != null)
            {
                UnityEngine.Vector2 playerVelocity = playerBody.velocity;
                playerVelocity.y = force;
                playerBody.velocity = playerVelocity;
               // playerBody.AddForce(transform.up * force);
                sprRenderer.sprite = springOutSprite;
            }
            springOutTimeLeft = 2.0f;
        }
    }
}
