using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Consumable : MonoBehaviour
{

    public Collider2D consumableCollider; 
    protected PlayerStats playerStats;
    protected WeaponStats weaponStats;
    protected PlayerData playerData;
    public float duration;
    Scene scene;
    
    
    public void Start(){
        Scene scene = SceneManager.GetActiveScene();
    }

    public void Update(){
        scene = SceneManager.GetActiveScene();
    }

    //on collision with a player delete the power up and cause the effect
    public void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Player") { //check if power up has collided with player
            playerStats = collision.gameObject.GetComponent<PlayerStats>();
            weaponStats = collision.gameObject.GetComponentInChildren<WeaponStats>(false);

            if(playerStats.playerName == "player1"){
                playerData = GameObject.Find("Player1Data(Clone)").GetComponent<PlayerData>();
            } else if(playerStats.playerName == "player2") {
                playerData = GameObject.Find("Player2Data(Clone)").GetComponent<PlayerData>();
            }
            

            if(scene.name != "BackRooms"){
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<Collider2D>().enabled = false;
                StartCoroutine(effect());
            } else {
                if(playerStats.levelUpgrades == 0){
                    playerStats.levelUpgrades = 1;
                    upgrade();
                }
            }
        }
    }

    protected abstract IEnumerator effect(); //effect of the power up
    
    protected abstract void upgrade();
}
