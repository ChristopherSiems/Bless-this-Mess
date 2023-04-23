using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour{
    private bool done = false;
    private Transform item;
    private GameObject player;
    private SpriteRenderer sprite;
    private GameObject stove;
    private GameObject fridge;
    public Sprite defrosted;

    // Start is called before the first frame update
    void Start(){
        item = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        stove = GameObject.FindWithTag("Stove");
        fridge = GameObject.FindWithTag("Fridge");
    }

    // Update is called once per frame
    // switches the task from incomplete to complete 
    void Update(){
        if (sprite.sprite == defrosted && !done){
            done = true;
            Sprite newSprite = Resources.Load<Sprite>("Checked_Box"); //name of completed sprite
            sprite.sprite = newSprite;
        }
        if (Input.GetKeyDown(KeyCode.Z) && fridge.GetComponent<Fridge>().reachable && !player.GetComponent<Player>().holding && !done){
            player.GetComponent<Player>().holding = true;
            player.GetComponent<Player>().chicken = true;
            transform.position = player.GetComponent<Player>().hands;
            item.SetParent(player.GetComponent<Transform>());
            sprite.sortingLayerName = "Held";
        }
        
    }

    public void Use(){
        if (stove.GetComponent<Stove>().reachable){
            player.GetComponent<Player>().chicken = false;
            player.GetComponent<Player>().holding = false;
            player.GetComponent<Transform>().DetachChildren();
            item.SetParent(stove.GetComponent<Transform>().GetChild(0));
            item.position = item.parent.position;
            sprite.sortingLayerName = "Laundry";
        }
    }
}

