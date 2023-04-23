using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairBottom : MonoBehaviour
{
    private GameObject player;
    private bool reachable = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (reachable && Input.GetKeyDown(KeyCode.Z)){
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            player.GetComponent<Player>().climbUp = true;
        }
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
