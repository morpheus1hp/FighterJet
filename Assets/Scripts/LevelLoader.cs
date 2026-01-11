using UnityEngine;
using UnityEngine.SceneManagement;   

public class LevelLoader : MonoBehaviour
    
{
    int currentIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(currentIndex+1);
    }
    public void Reload()
    {
        SceneManager.LoadScene(currentIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
