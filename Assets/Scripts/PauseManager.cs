using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI; 
    public GameObject player; 
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; 
        isPaused = true;

        if (player != null)
        {
            var controller = player.GetComponent<CharacterController>();
            if (controller != null)
                controller.enabled = false;
        }                                
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; 
        isPaused = false;

        if (player != null)
        {
            var controller = player.GetComponent<CharacterController>();
            if (controller != null)
                controller.enabled = true;
        }                                   
    }

    public void Regresar()
    {

        SceneManager.LoadScene("PrincipalMenu"); 
        Resume(); 
        
       
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MenuPrincipal"); 
    }
}
