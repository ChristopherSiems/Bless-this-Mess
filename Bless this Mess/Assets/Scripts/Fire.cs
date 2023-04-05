using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour{
    private GameObject player;
    private float knockbackDir;
    public float knockback;

    // Start is called before the first frame update
    void Start(){
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update(){
        if (player.GetComponent<SpriteRenderer>().flipX){
            knockbackDir = 1;
        }
        else{
            knockbackDir = -1;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject == player){
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            player.GetComponent<Rigidbody2D>().AddForce(transform.right * knockbackDir * knockback, ForceMode2D.Impulse);
        }
    }
}