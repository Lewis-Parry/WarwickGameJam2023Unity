using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{

    private GameObject[] players;
    public GameObject winScreen;
    private PlayerData playerData;

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
           

            
            if(playerStats.isAlive == false) { //checks a player is alive

                players[i].GetComponent<SpriteRenderer>().enabled = false;
                if(playerStats.playerName == "player1") {
                   PlayerData playerData = GameObject.Find("Player1Data(Clone)").GetComponent<PlayerData>(); 
                   playerData.numberWins -= 1;

                } else {
                    PlayerData playerData = GameObject.Find("Player2Data(Clone)").GetComponent<PlayerData>();
                    playerData.numberWins -= 1;
                }

                

                Scene scene = SceneManager.GetActiveScene();

                if(scene.name != "Level5"){
                    SceneManager.LoadScene("BackRooms");
                } else {
                        PlayerData playerData1 = GameObject.Find("Player1Data(Clone)").GetComponent<PlayerData>();
                        PlayerData playerData2 = GameObject.Find("Player2Data(Clone)").GetComponent<PlayerData>();

                        if(playerData2.numberWins < playerData1.numberWins){
                            win();
                            Time.timeScale = 0;
                        } else {
                            return;
                        }
                }       
            }
        }
    }

    private void win() { //win game
        winScreen.SetActive(true); //shows win screen
    }

    public void Exit() { //quits to main menu
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
