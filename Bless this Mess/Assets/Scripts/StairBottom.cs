using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairBottom : MonoBehaviour
{
    private GameObject player;
    private bool reachable = false;
    public Transform top;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (reachable && Input.GetKeyDown(KeyCode.Z)){
            player.GetComponent<Player>().climb(top);
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
