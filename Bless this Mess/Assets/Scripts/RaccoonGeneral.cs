using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaccoonGeneral : MonoBehaviour
{
    public float knockback = 1f;
    public float knockbackDir = 1f;

    public Transform player;

    public bool isFlipped = false;
    private GameObject Player;
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
        else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player)
        {
            Player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            Player.GetComponent<Rigidbody2D>().AddForce(transform.right * knockbackDir * knockback, ForceMode2D.Impulse);
            Player.GetComponent<Player>().TakeDamage(20);
        }
    }
}
