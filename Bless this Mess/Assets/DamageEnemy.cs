using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    private BoxCollider2D hb;
    public Transform player;
    private float knockbackDir;
    public float knockback;




    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        hb = boxCollider2D;
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        

        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            player.GetComponent<Rigidbody2D>().AddForce(transform.up * knockbackDir * knockback, ForceMode2D.Impulse);
            Destroy(transform.parent.gameObject);


        }
    }
}
