using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Player : MonoBehaviour
{

    int health = 3;
    int keys = 0;

    Rigidbody2D rb2d;
    CapsuleCollider2D coll;
    Animator anim;

    [SerializeField] LayerMask lethalLayer;
    [SerializeField] GameObject respawnPoint;

    public delegate void OnAttributeChangedDelegate(int newValue);

    public OnAttributeChangedDelegate onHealthChanged;
    public OnAttributeChangedDelegate onKeysChanged;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("Speed", Math.Abs(rb2d.velocity.x));
        anim.SetFloat("VerticalSpeed", Math.Abs(rb2d.velocity.y));
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(IsGameObjectLethal(coll.gameObject))
        {
            transform.position = respawnPoint.transform.position;
            SetHealth(health - 1);
        }
        else if(coll.gameObject.tag == "Key")
        {
            SetKeyCount(keys + 1);
            Destroy(coll.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(IsGameObjectLethal(coll.gameObject))
        {
            transform.position = respawnPoint.transform.position;
            SetHealth(health - 1);
        }
    }

    public void SetKeyCount(int newKeyCount)
    {
        if(newKeyCount < 0 || newKeyCount > 3)
        {
            return;
        }

        keys = newKeyCount;

        if(onKeysChanged != null)
        {
            onKeysChanged(keys);
        }
    }

    public void SetHealth(int newHealth)
    {
        if(newHealth < 0 || newHealth > 3)
        {
            return;
        }

        health = newHealth;

        if(onHealthChanged != null)
        {
            onHealthChanged(health);
        }
    }

    bool IsGameObjectLethal(GameObject obj)
    {
        return ((1 << obj.layer) & lethalLayer.value) != 0;
    }
}

