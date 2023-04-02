using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    private Rigidbody2D player;
    private bool grounded = false;
    public bool itemBasic = false;
    public float forceH;
    public float maxSpeedH;
    public float forceV;

    // Start is called before the first frame update
    void Start(){
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        if (!(Mathf.Abs(player.velocity.x) > maxSpeedH)){
            player.AddForce(transform.right * forceH * Input.GetAxis("Horizontal"));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded){
            player.AddForce(transform.up * forceV, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.transform.position.y < player.position.y){
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other){
        if (other.gameObject.transform.position.y < player.position.y){
            grounded = false;
        }
    }
}
