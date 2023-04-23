using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairTop : MonoBehaviour
{
    /*private GameObject player;
    private Transform bottom;
    private bool reachable = false;
    public GameObject floor;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        bottom = transform.parent.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (reachable && Input.GetKeyDown(KeyCode.Z)){
            player.GetComponent<Player>().climbingDown = true;
        }
        if (player.GetComponent<Player>().climbingDown && player.GetComponent<Transform>().position != bottom.position){
            Physics2D.IgnoreCollision(floor.GetComponent<BoxCollider2D>(), player.GetComponent<BoxCollider2D>(), true);
            player.GetComponent<Transform>().position = Vector3.MoveTowards(player.GetComponent<Transform>().position, bottom.position, .05f);
        }
        else{
            player.GetComponent<Player>().climbingDown = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject == player && !player.GetComponent<Player>().climbingUp){
            reachable = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject == player){
            reachable = false;
        }
    }*/
}
