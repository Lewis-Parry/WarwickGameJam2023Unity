using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    private bool isLeft;
    private float horizontal = 1;
    private float input = 1;
    
    Quaternion wantedRotation; // where to rotate to when swinging 

    private string fireKey;

    private bool collided = false; // if the sword has collding with the player during the current swing
    private bool isSwinging = false; 

    private float damage = 10;

    public WeaponStats weaponStats;
    public PlayerStats playerStats; 
    
    public GameObject pivot; // pivot to rotate around

    // Start is called before the first frame update
    void Start()
    {
      gameObject.GetComponent<SpriteRenderer>().enabled = false; //makes sword invisible
      getPlayerFireKey(); 
    }

    // Update is called once per frame
    void Update()
    {
        getHorizontalInput(); 

        if (Input.GetButtonUp(fireKey) || isSwinging) //if fire key switched start swinging and continue swinging not at 90 degrees
        {
           Swing();
        }
    }

    
    public void OnTriggerEnter2D(Collider2D collision) //on collision 
    {
        if(collision.tag == "Player") { // check if collided with a player 

            if(!isSwinging || collided) { // if the sword is not swinging or has already hit a player return
                return;
            }

            collided = true; 

            PlayerHealth enemyHealth = collision.gameObject.GetComponent<PlayerHealth>(); //gets enemy health
            PlayerStats enemyStats = collision.gameObject.GetComponent<PlayerStats>(); //gets enemy stats

            if(enemyStats.playerName == playerStats.playerName){ // if colliding with sword owner return
                return;
            }
            enemyHealth.TakeDamage(damage); //deal damage to player
        }
    }


    void getHorizontalInput() { //returns the correct horizontal input depending on the player
        if(playerStats.playerName == "player1"){ // if sword owner is player 1
            input = Input.GetAxisRaw("Horizontal"); // get horizontal input , 0, 1 ,-1
            if(input == 0) { // if going in no direction return
                return;
            }
            horizontal = input; //sets horizontal direction
        } else {
            input = Input.GetAxisRaw("Horizontal2");
            if(input == 0) {
                    return;
            }
            horizontal = input;
        }
    }


    void Swing() {
        Quaternion currentRotation = pivot.transform.rotation; //gets current rotation

        gameObject.GetComponent<SpriteRenderer>().enabled = true; //makes sword visable
        isSwinging = true;

        setRotationDirection(); 

        if(pivot.transform.rotation == wantedRotation){ //checks if the sword has finished rotating
            Reset();
            return;
        }
        if(isSwinging) {
            pivot.transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime*weaponStats.fireRate); // swing
        }
    }

    void setRotationDirection() { //sets direction to swing based on direction player is facing
        if(horizontal == 1){
            wantedRotation = Quaternion.Euler(0,0,-90);
        } else {
            wantedRotation = Quaternion.Euler(0,0,90);
        }
    }

    void Reset() { // reset after finishing swinging 
        isSwinging = false;
        collided = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false; // turn invisible
        pivot.transform.rotation = Quaternion.identity; // turn upright
    }

    void getPlayerFireKey() { //gets the fire key of sword owner
        if(playerStats.playerName == "player1"){
            fireKey = "Fire1";
        } else if(playerStats.playerName == "player2") {
            fireKey = "Fire2";
        }
    }
}


