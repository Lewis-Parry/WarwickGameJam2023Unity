using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public PlayerStats playerStats;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(playerStats.health);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }

        if(playerStats.health == 0) {
            playerStats.numberLives =- 1;
        }

        if(playerStats.numberLives <= 0){
            playerStats.isAlive = false;
        }
    }

    void TakeDamage(float damage)
    {
        playerStats.health -= damage;
        healthBar.SetHealth(playerStats.health);
    }
}
