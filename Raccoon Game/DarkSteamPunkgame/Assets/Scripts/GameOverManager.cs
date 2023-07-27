
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverManager : MonoBehaviour
{
   
    public GameObject pauseMenu;
    public GameObject ResumeGameButton;
    public bool isPaused;
    public AudioSource AudioPlayer;
    public AudioSource raccooninabag;


   
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
            AudioPlayer.Play();
            raccooninabag.Play();
            GameOver();
            Debug.Log("Dead");
        }

    }
    // When Player is killed UI is triggered active
    public void GameOver()
    {
    
        pauseMenu.SetActive(true);
        ResumeGameButton.SetActive(false);
     

       
        

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
   
    }

    //If Restart button is clicked scene is reloaded
    public void Restart()
    {
        
        SceneManager.LoadScene("GameArea");
        Time.timeScale = 1f;




    }

    // If Main menu button is clicked Player is taken back to main menu 
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;

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
