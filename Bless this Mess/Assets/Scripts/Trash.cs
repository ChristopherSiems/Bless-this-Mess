using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour{
    private bool grabable = false;
    private bool done = false;
    private Transform item;
    private GameObject player;
    private SpriteRenderer sprite;
    private GameObject trashcan;

    // Start is called before the first frame update
    void Start(){
        item = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        trashcan = GameObject.FindWithTag("Trashcan");
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Z) && grabable && !player.GetComponent<Player>().holding){
            player.GetComponent<Player>().holding = true;
            player.GetComponent<Player>().trash = true;
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
        if (Vector3.Distance(trashcan.GetComponent<Transform>().position, transform.position) < 2){
            player.GetComponent<Player>().trash = false;
            player.GetComponent<Player>().holding = false;
            Destroy(gameObject);
            done = true;
            Sprite newSprite = Resources.Load<Sprite>("Checked_Box"); //name of completed sprite
            sprite.sprite = newSprite;
        }
    }
}