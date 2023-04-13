using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rat : MonoBehaviour{
    private Vector3 limit1, limit2, next;
    private GameObject player;
    private Rigidbody2D rat;
    private SpriteRenderer sprite;
    private float knockbackDir;
    public float speed;
    public float knockback;
    public bool dead = false;

    // Start is called before the first frame update
    void Start(){
        player = GameObject.FindWithTag("Player");
        rat = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        limit1 = transform.GetChild(0).position;
        limit2 = transform.GetChild(1).position;
        next = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update(){
        if (player.GetComponent<SpriteRenderer>().flipX){
            knockbackDir = 1;
        }
        else{
            knockbackDir = -1;
        }
        if (!dead){
            if (next.x > transform.position.x){
                sprite.flipX = false;
            }
            else if (next.x < transform.position.x){
                sprite.flipX = true;
            }
            if (transform.position == next){
                next = new Vector3(Random.Range(limit1.x, limit2.x), transform.position.y, transform.position.z);
            }
            transform.position = Vector3.MoveTowards(transform.position, next, speed * Time.deltaTime);
        }
        else{
            rat.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject == player && !dead){
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            player.GetComponent<Rigidbody2D>().AddForce(transform.right * knockbackDir * knockback, ForceMode2D.Impulse);
        }
    }
}