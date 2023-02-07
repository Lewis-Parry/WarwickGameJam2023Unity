using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    private bool movingLevel;
    private int numberUpgrades;
    public int secondsTillNext = 5;
    private GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player"); //updates player store
    }

    // Update is called once per frame
    void Update()
    {
       numberUpgrades = players[0].GetComponent<PlayerStats>().levelUpgrades + players[1].GetComponent<PlayerStats>().levelUpgrades;


        if(numberUpgrades == 2 && !movingLevel){
            StartCoroutine(moveLevel());
        }     
    }

    private IEnumerator moveLevel(){
        movingLevel = true;
        yield return new WaitForSeconds(secondsTillNext);
        SceneManager.LoadScene(GameObject.Find("Player1Data(Clone)").GetComponent<PlayerData>().currentLevel + 1);

    }
    
}
