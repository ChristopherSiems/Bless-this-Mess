using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    private Rigidbody2D player;
    private Transform playerT;
    private bool grounded = false;
    public bool itemBasic = false;
    public bool fireExtinguisher = false;
    public float forceH;
    public float maxSpeedH;
    public float forceV;
    public Vector3 hands;

    // Start is called before the first frame update
    void Start(){
        player = GetComponent<Rigidbody2D>();
        playerT = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update(){
        hands = new Vector3(playerT.transform.position.x, playerT.transform.position.y, playerT.transform.position.z - .1f);
        if (!(Mathf.Abs(player.velocity.x) > maxSpeedH)){
            player.AddForce(transform.right * forceH * Input.GetAxis("Horizontal"));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded){
            player.AddForce(transform.up * forceV, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        grounded = true;
    }

    void OnTriggerStay2D(Collider2D other){
        grounded = true;
    }

    void OnTriggerExit2D(Collider2D other){
        grounded = false;
    }
}