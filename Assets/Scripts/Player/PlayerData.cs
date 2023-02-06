using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{

    public int numberJumps;
    public bool dashUnlocked;
    public bool slamUnlocked;
    public bool slamDmgUnlocked;
    public bool dashDmgUnlocked;
    public string playerName;
    public int numberLives;
    public float maxHealth;
    private int numScenes;

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
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if(scene.name == "MainMenu" & numScenes != 0) {
            Debug.Log("destroying");
            Destroy(gameObject);
        } else {
            Debug.Log(numScenes + scene.name);
            numScenes = 1;
        }
    }
}
