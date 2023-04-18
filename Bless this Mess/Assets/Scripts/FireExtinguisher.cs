using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour{
    private bool grabable = false;
    private bool done = false;
    private Transform item;
    private GameObject player;
    private SpriteRenderer sprite;
    private GameObject fire;

    // Start is called before the first frame update
    void Start(){
        item = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        fire = GameObject.FindWithTag("Fire");
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Z) && grabable && !player.GetComponent<Player>().holding){
            player.GetComponent<Player>().holding = true;
            player.GetComponent<Player>().fireExtinguisher = true;
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
        if (Vector3.Distance(fire.GetComponent<Transform>().position, transform.position) < 2){
            Destroy(fire);
            player.GetComponent<Player>().fireExtinguisher = false;
            player.GetComponent<Player>().holding = false;
            Destroy(gameObject);
        }
        // switches the task from incomplete to complete 
        if (!fire) {
            done = true;
            Sprite newSprite = Resources.Load<Sprite>("Checked_Box"); //name of completed sprite
            sprite.sprite = newSprite;
}


    }
}