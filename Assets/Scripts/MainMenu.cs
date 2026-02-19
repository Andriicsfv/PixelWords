using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
    public void OpenSettings()
    {
        Debug.Log("Налаштування відкрито!");
        
    }

    
    public void QuitGame()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}
