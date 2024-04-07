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

    [SerializeField] LayerMask lethalLayer;
    [SerializeField] GameObject respawnPoint;

    public delegate void OnDeathDelegate();
    public delegate void OnAttributeChangedDelegate(int newValue);

    public OnDeathDelegate onDeath;
    public OnAttributeChangedDelegate onHealthChanged;
    public OnAttributeChangedDelegate onKeysChanged;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(((1 << coll.gameObject.layer) & lethalLayer.value) != 0)
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
        if(((1 << coll.gameObject.layer) & lethalLayer.value) != 0)
        {
            transform.position = respawnPoint.transform.position;
            SetHealth(health - 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetKeyCount(int newKeyCount)
    {
        if(newKeyCount < 0 || newKeyCount > 3)
        {
            return;
        }

        keys = newKeyCount;
        onKeysChanged(keys);
    }

    public void SetHealth(int newHealth)
    {
        if(newHealth < 0 || newHealth > 3)
        {
            return;
        }

        health = newHealth;
        onHealthChanged(health);

        if(health == 0)
        {
            onDeath();
        }
    }
}

