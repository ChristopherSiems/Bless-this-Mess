using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laundry : MonoBehaviour{
    private Transform item;
    private GameObject player;
    private SpriteRenderer sprite;
    private GameObject washer;
    private GameObject dryer;

    // Start is called before the first frame update
    void Start(){
        item = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        washer = GameObject.FindWithTag("Washer");
        dryer = GameObject.FindWithTag("Dryer");
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Z) && !player.GetComponent<Player>().holding && washer.GetComponent<Washer>().reachable){
            player.GetComponent<Player>().holding = true;
            player.GetComponent<Player>().laundry = true;
            transform.position = player.GetComponent<Player>().hands;
            item.SetParent(player.GetComponent<Transform>());
            sprite.sortingLayerName = "Held";
        }
    }

    public void Use(){
        if (dryer.GetComponent<Dryer>().reachable){
            player.GetComponent<Player>().trash = false;
            player.GetComponent<Player>().holding = false;
            Destroy(gameObject);
        }
    }
}