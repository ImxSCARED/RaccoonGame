using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;


    // When Player is killed UI is triggered active
    public void GameOver()
    {
    
        gameOverUI.SetActive(true);

   
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
     
    }

   
    
}
