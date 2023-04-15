using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour{
    private bool grabable = false;
    private bool done = false;
    private Transform item;
    private GameObject player;
    private SpriteRenderer sprite;
    private GameObject stove;
    public Sprite defrosted;

    // Start is called before the first frame update
    void Start(){
        item = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        stove = GameObject.FindWithTag("Stove");
    }

    // Update is called once per frame
    void Update(){
        if (sprite.sprite == defrosted){
            done = true;
        }
        if (Input.GetKeyDown(KeyCode.Z) && grabable && !player.GetComponent<Player>().holding && !done){
            player.GetComponent<Player>().holding = true;
            player.GetComponent<Player>().chicken = true;
            transform.position = player.GetComponent<Player>().hands;
            item.SetParent(player.GetComponent<Transform>());
            sprite.sortingLayerName = "Held";
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject == player){
            grabable = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject == player){
            grabable = false;
        }
    }

    public void Use(){
        if (stove.GetComponent<Stove>().reachable){
            player.GetComponent<Player>().chicken = false;
            player.GetComponent<Player>().holding = false;
            player.GetComponent<Transform>().DetachChildren();
            item.SetParent(stove.GetComponent<Transform>().GetChild(0));
            item.position = item.parent.position;
            sprite.sortingLayerName = "Background";
        }
    }
}