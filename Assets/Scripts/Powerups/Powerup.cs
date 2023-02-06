using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{

    public Collider2D powerupCollider; 
    protected PlayerStats playerStats;
    protected WeaponStats weaponStats;

    //on collision with a player delete the power up and cause the effect
    public void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Player") { //check if power up has collided with player
            playerStats = collision.gameObject.GetComponent<PlayerStats>();
            weaponStats = collision.gameObject.GetComponentInChildren<WeaponStats>(false);
            effect();
            Destroy(gameObject); //destroys the powerup
        }
    }

    protected abstract void effect(); //effect of the power up
}
