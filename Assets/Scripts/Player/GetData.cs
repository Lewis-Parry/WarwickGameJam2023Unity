using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetData : MonoBehaviour
{

    public PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
       PlayerStats playerStats = gameObject.GetComponent<PlayerStats>();

        if(playerStats.name == "player1"){
            playerData = GameObject.Find("Player1Data(Clone)").GetComponent<PlayerData>();
       } else {
            playerData = GameObject.Find("Player2Data(Clone)").GetComponent<PlayerData>();
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
