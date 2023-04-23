using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour{
    private Rigidbody2D player;
    private Transform playerT;
    private SpriteRenderer sprite;
    private bool grounded = false;
    private Animator anim;
    public Vector3 hands;
    public bool itemBasic = false;
    public bool fireExtinguisher = false;
    public bool chicken = false;
    public bool hairDryer = false;
    public bool trash = false;
    public bool holding = false;
    public bool trap = false;
    public bool laundry = false;
    public float forceH;
    public float maxSpeedH;
    public float forceV;
    public int maxHealth = 100;
    public int currentHealth;
    public UIHealth healthBar;
    public int scene;
    public GameObject floor;

    // Start is called before the first frame update
    void Start(){
        player = GetComponent<Rigidbody2D>();
        playerT = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update(){
        hands = new Vector3(playerT.transform.position.x, playerT.transform.position.y, playerT.transform.position.z - .1f);
        if (Input.GetKeyDown(KeyCode.X) && holding){
            if (fireExtinguisher){
                playerT.GetChild(0).GetComponent<FireExtinguisher>().Use();
            }
            else if (chicken){
                playerT.GetChild(0).GetComponent<Chicken>().Use();
            }
            else if (hairDryer){
                playerT.GetChild(0).GetComponent<HairDryer>().Use();
            }
            else if (trash){
                playerT.GetChild(0).GetComponent<Trash>().Use();
            }
            else if (trap){
                playerT.GetChild(0).GetComponent<Trap>().Use();
            }
            else if (laundry){
                playerT.GetChild(0).GetComponent<Laundry>().Use();
            }
        }
        if (player.velocity.x > 0f){
            sprite.flipX = false;
        }
        else if (player.velocity.x < 0f){
            sprite.flipX = true;
        }
        if (!(Mathf.Abs(player.velocity.x) > maxSpeedH)){
            player.AddForce(transform.right * forceH * Input.GetAxis("Horizontal"));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded){
            player.AddForce(transform.up * forceV, ForceMode2D.Impulse);
            anim.SetBool("jump", true);
        }
        else{
            anim.SetBool("jump", false);
        }
        if (currentHealth <= 0){
            SceneManager.LoadScene(scene);
        }
        if (Mathf.Abs(player.velocity.x) > .1f){
            anim.SetBool("walk", true);
        }
        else{
            anim.SetBool("walk", false);
        }
        /*if(Input.GetKeyDown(KeyCode.P)){
            TakeDamage(100);
        }*/
    }

    /*private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Enemy"){
            TakeDamage(20);
        }
    }*/

    void OnTriggerEnter2D(Collider2D other){
        if (!(other.gameObject.tag == "Item")){
            grounded = true;
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if (!(other.gameObject.tag == "Item")){
            grounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        grounded = false;
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void climb(Transform target){
        while (transform.position != target.position){
            anim.SetBool("walk", true);
            player.velocity = new Vector3(0, 0, 0);
            Physics2D.IgnoreCollision(floor.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>(), true);
            player.position = Vector3.MoveTowards(player.position, target.position, .05f);
        }
    }
}