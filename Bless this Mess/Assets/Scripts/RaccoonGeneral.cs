using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaccoonGeneral : MonoBehaviour
{
    
    private float knockbackDir;
    public float knockback;
    public Transform player;
    public float WalkRange = 60f;
    public int health = 100;
    public SpriteRenderer sprite;
    

    public bool isFlipped = false;
    public Player playerdamage;
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    private void Update()
    {
        knockbackDir = player.GetComponent<SpriteRenderer>().flipX ? 1 : (float)-1;
        if(health <= 0f)
        {
            Destroy(GetComponent<Rigidbody2D>());
            sprite.flipY = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            player.GetComponent<Rigidbody2D>().AddForce(transform.right * knockbackDir * knockback, ForceMode2D.Impulse);
            playerdamage.TakeDamage(20);
        }
    }

}