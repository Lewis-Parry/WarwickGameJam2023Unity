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

    //on collision with a player delete the power up and cause the effect
    public void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Player") { //check if power up has collided with player
            playerStats = collision.gameObject.GetComponent<PlayerStats>();
            weaponStats = collision.gameObject.GetComponentInChildren<WeaponStats>(false);

            if(playerStats.name == "player1"){
                playerData = GameObject.Find("Player1Data").GetComponent<PlayerData>();
            } else{
                playerData = GameObject.Find("Player2Data").GetComponent<PlayerData>();
            }
            playerStats.levelUpgrades += 1;

            if(scene.name != "LevelTransition"){
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<Collider2D>().enabled = false;
                StartCoroutine(effect());
                //destroys the powerup
            } else {
                upgrade();
                Destroy(gameObject); 
            }
        }
    }

    protected abstract IEnumerator effect(); //effect of the power up
    
    protected abstract void upgrade();
}
