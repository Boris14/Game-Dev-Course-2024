using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform leftBound;
    [SerializeField] Transform rightBound;
    [SerializeField] float speed = 2;
    
    float direction = -1;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(direction * speed, rb2d.velocity.y);

        if(direction == -1 && transform.position.x <= leftBound.position.x)
        {
            direction = 1;
        }
        else if(direction == 1 && transform.position.x >= rightBound.position.x)
        {
            direction = -1;
        }
    }
}
