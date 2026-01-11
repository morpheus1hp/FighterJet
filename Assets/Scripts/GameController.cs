using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject GameOverPanel;
    public GameObject levelCompletePanel;
    public GameObject endText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1f;
        endText.SetActive(false);
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        GameOverPanel.SetActive(false);
        levelCompletePanel.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }
   
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        pauseButton.SetActive(false);
      //  Time.timeScale = 0f;
    }
    public IEnumerator LevelComplete()
    {
        yield return new WaitForSeconds(2f);
        endText.SetActive(true);
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
        levelCompletePanel.SetActive(true);
       // pauseButton.SetActive(false);
        //  Time.timeScale = 0f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
