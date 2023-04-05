using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehavior : MonoBehaviour{
    private Vector3 nextPos;
    public Transform startbPos, posb1, posb2;
    public float speed;
    public int Respawn;

    // Start is called before the first frame update
    void Start(){
        nextPos = startbPos.position;
    }

    // Update is called once per frame
    void Update(){
        if (transform.position == posb1.position){
            nextPos = posb2.position;
        }
        else if (transform.position == posb2.position){
            nextPos = posb1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(Respawn);
        }
    }
}