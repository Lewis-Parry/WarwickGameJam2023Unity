using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{

    public int numberJumps;
    public bool dashUnlocked;
    public bool slamUnlocked;
    public string playerName;
    public int numberLives;
    public float maxHealth;
    public int currentLevel;
    public int numberWins = 0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad (gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Reset(){
        
         numberJumps = 0;
         dashUnlocked = false;
         slamUnlocked= false;
         numberLives = 0;
         maxHealth = 100;
         numberWins = 0;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        
        if(scene.name == "MainMenu") {
            Debug.Log("Resetting");
            Reset();
        } else if(scene.name != "BackRooms"){
            currentLevel = SceneManager.GetActiveScene().buildIndex;
        }
    }

    private void OnDestroy(){
    // Always clean up your listeners when not needed anymore
    SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
