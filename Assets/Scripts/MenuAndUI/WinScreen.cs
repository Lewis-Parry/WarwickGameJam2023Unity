using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{

    private GameObject[] players;
    public GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player"); //stores all players
        winScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        players = GameObject.FindGameObjectsWithTag("Player"); //updates player store

        for (int i = 0; i < players.Length; i++) //iterates through list of players and checks if they are alive 
        {
            PlayerStats playerStats = (PlayerStats) players[i].GetComponent<PlayerStats>(); //stores a given players stats

            if(playerStats.isAlive == false) { //checks if this player is alive
                win();           
            }
        }
    }

    private void win() { //win game
        winScreen.SetActive(true); //shows win screen
    }

    public void Exit() { //quits to main menu
        SceneManager.LoadScene("MainMenu");
    }
}
