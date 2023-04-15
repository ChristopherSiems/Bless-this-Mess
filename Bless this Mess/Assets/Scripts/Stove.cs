using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour{
    public bool reachable = false;
    private GameObject player;

    // Start is called before the first frame update
    void Start(){
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update(){
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject == player){
            reachable = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject == player){
            reachable = false;
        }
    }
}