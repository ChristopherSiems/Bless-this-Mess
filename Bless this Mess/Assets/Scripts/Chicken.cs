using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour{
    private bool grabable = false;
    private bool done = false;
    private Transform item;
    private GameObject player;
    private SpriteRenderer sprite;
    public Sprite defrosted;

    // Start is called before the first frame update
    void Start(){
        item = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    // switches the task from incomplete to complete 
    void Update(){
        if (sprite.sprite == defrosted && !done){
            done = true;
            Sprite newSprite = Resources.Load<Sprite>("Checked_Box"); //name of completed sprite
            sprite.sprite = newSprite;
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
}

