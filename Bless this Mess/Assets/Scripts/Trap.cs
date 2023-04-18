using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour{
    private bool grabable = false;
    private Transform item;
    private bool done = false;
    private GameObject player;
    private SpriteRenderer sprite;
    private Rigidbody2D trap;
    private EdgeCollider2D bottom;
    public Sprite sprung;

    // Start is called before the first frame update
    void Start(){
        item = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        trap = GetComponent<Rigidbody2D>();
        bottom = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Z) && grabable && !player.GetComponent<Player>().holding && sprite.sprite != sprung){
            player.GetComponent<Player>().holding = true;
            player.GetComponent<Player>().trap = true;
            trap.position = player.GetComponent<Player>().hands;
            item.SetParent(player.GetComponent<Transform>());
            sprite.sortingLayerName = "Held";
        }
        if (transform.parent == player.transform){
            trap.gravityScale = 0;
            Physics2D.IgnoreCollision(bottom, player.GetComponent<BoxCollider2D>(), true);
            trap.position = player.GetComponent<Player>().hands;
        }
        else{
            trap.gravityScale = 1;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject == player){
            grabable = true;
        }
        else if (other.gameObject.tag == "Rat" && sprite.sprite != sprung){
            other.gameObject.GetComponent<Rat>().dead = true;
            other.gameObject.GetComponent<SpriteRenderer>().flipY = true;
            sprite.sprite = sprung;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject == player){
            grabable = false;
        }
    }

    public void Use(){
        player.GetComponent<Player>().trap = false;
        player.GetComponent<Player>().holding = false;
        player.GetComponent<Transform>().DetachChildren();

        // Check if trap is no longer being held and player is no longer in trap
        if (!player.GetComponent<Player>().holding && !player.GetComponent<Player>().trap) {
            done = true;
            Sprite newSprite = Resources.Load<Sprite>("Checked_Box"); //name of completed sprite
            sprite.sprite = newSprite;
    }
    }
}