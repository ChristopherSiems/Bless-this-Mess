using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour{
    private bool grabable = false;
    private Transform item;
    private GameObject player;
    private SpriteRenderer sprite;
    private Rigidbody2D trap;
    private EdgeCollider2D edge;
    public Sprite sprung;

    // Start is called before the first frame update
    void Start(){
        item = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        trap = GetComponent<Rigidbody2D>();
        edge = GetComponent<EdgeCollider2D>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Z) && grabable && !player.GetComponent<Player>().holding){
            trap.gravityScale = 0;
            edge.isTrigger = true;
            player.GetComponent<Player>().holding = true;
            player.GetComponent<Player>().itemBasic = true;
            transform.position = player.GetComponent<Player>().hands;
            item.SetParent(player.GetComponent<Transform>());
            sprite.sortingLayerName = "Held";
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject == player && sprite.sprite != sprung){
            grabable = true;
        }
        else if (other.gameObject.tag == "Rat"){
            other.gameObject.GetComponent<Rat>().dead = true;
            other.gameObject.GetComponent<SpriteRenderer>().flipY = true;
            sprite.sprite = sprung;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject == player && sprite.sprite != sprung){
            grabable = false;
            edge.isTrigger = false;
        }
    }

    public void Use(){
        player.GetComponent<Player>().trap = false;
        player.GetComponent<Player>().holding = false;
        player.GetComponent<Transform>().DetachChildren();
        trap.gravityScale = 1;
    }
}