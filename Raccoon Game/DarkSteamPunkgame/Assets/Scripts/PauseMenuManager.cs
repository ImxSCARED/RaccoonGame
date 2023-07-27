using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerScript : MonoBehaviour
{
   
    public GameObject pauseMenu;
    public bool isPaused;


    void Start()
    {
        pauseMenu.SetActive(false);   
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            PauseGame();

        }
    }


    public void PauseGame()
    {
              
         pauseMenu.SetActive(true);
         Time.timeScale = 0f;
         Cursor.lockState = CursorLockMode.None;
         Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }

    public void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {

            GameOver();
            Debug.Log("Dead");
        }

    }
    // When Player is killed UI is triggered active
    public void GameOver()
    {
    
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
   
    }

    //If Restart button is clicked scene is reloaded
    public void Restart()
    {
        
        SceneManager.LoadScene("GameArea");
        

    }

    // If Main menu button is clicked Player is taken back to main menu 
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
      
    }

    // If Quit button is clicked applicatin will close 
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    //From the main menu, if clicked will load game scene 
    public void StartGame()
    {
       
        SceneManager.LoadScene("GameArea");
        Cursor.lockState = CursorLockMode.None;
       

    }
    

   
    
}
