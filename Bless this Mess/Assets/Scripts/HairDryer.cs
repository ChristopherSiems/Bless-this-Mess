using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairDryer : MonoBehaviour{
    private bool grabable = false;
    private Transform item;
    private GameObject player;
    private SpriteRenderer sprite;
    private GameObject chicken;
    public Sprite defrosted;
    public GameObject manager;

    // Start is called before the first frame update
    void Start(){
        item = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        chicken = GameObject.FindWithTag("Chicken");
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Z) && grabable && !player.GetComponent<Player>().holding){
            player.GetComponent<Player>().holding = true;
            player.GetComponent<Player>().hairDryer = true;
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
        if (Vector3.Distance(chicken.GetComponent<Transform>().position, transform.position) < 2){
            chicken.GetComponent<SpriteRenderer>().sprite = defrosted;
            player.GetComponent<Player>().hairDryer = false;
            player.GetComponent<Player>().holding = false;
            item.GetChild(0).GetComponent<AudioSource>().Play();
            item.DetachChildren();
            chicken.GetComponent<SpriteRenderer>().sortingLayerName = "Laundry";
            Destroy(gameObject);
            manager.GetComponent<GameManager>().chicken = true;
        }
    }
}