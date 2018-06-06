using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour {

    [SerializeField]
    Transform PausePanel;//Will assign our panel to this variable so we can enable/disable it  

    bool isPaused; //Used to determine paused state  

    // Use this for initialization
    void Start()
    {
        PausePanel.gameObject.SetActive(false); //make sure our pause menu is disabled when scene starts  
        isPaused = false; //make sure isPaused is always false when our scene opens  
    }

    // Update is called once per frame
    void Update()
    {

        //If player presses escape and game is not paused. Pause game. If game is paused and player presses escape, unpause.  
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
            Pause();
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
            UnPause();
    }

    public void Pause()
    {
        isPaused = true;
        PausePanel.gameObject.SetActive(true); //turn on the pause menu  
        Time.timeScale = 0f; //pause the game  
    }

    public void UnPause()
    {
        isPaused = false;
        PausePanel.gameObject.SetActive(false); //turn off pause menu  
        Time.timeScale = 1f; //resume game  
    }

    public void Restart()
    {
        Application.LoadLevel(0);
    }
}
