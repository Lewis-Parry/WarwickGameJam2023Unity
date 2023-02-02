using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public bool isPaused = false;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //allows escape key to pause and resume game
        {
            if(isPaused) {
                Resume();
            } else {
                Pause();
            }

        }

    }
        
    public void Pause() {
        pauseMenu.SetActive(true);//brings up pause menu
        Time.timeScale = 0f; //slows progression of time to 0
        isPaused = true; 
    }

    public void Resume() {
        pauseMenu.SetActive(false); // hides pause menu
        Time.timeScale = 1f; //resumes time
        isPaused = false; 
    }

    public void Exit() {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}
