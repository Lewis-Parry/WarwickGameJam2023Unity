using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    SceneManager.LoadScene("Level5");

        //}

        if(playerStats.health <= 0) { //if health is 0 take away a life
            playerStats.numberLives =- 1;
        }

        if(playerStats.numberLives <= 0){ //if no lives are remaining die
            playerStats.isAlive = false;
        }
    }

    public void TakeDamage(float damage)
    {
        FindObjectOfType<AudioManager>().Play("takeDamage");
        playerStats.health -= damage;
        healthBar.SetHealth(playerStats.health);
    }
}
