using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.Audio; 

public class SettingsMenu : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject settingsPanel; 
    public Slider musicSlider;       

    private bool isSettingsOpen = false;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isSettingsOpen)
                CloseSettings();
            else
                OpenSettings();
        }
    }

   
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        isSettingsOpen = true;
         
    }

    
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        isSettingsOpen = false;
        
    }

    
    public void BackToMainMenu()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    
    public void SetVolume(float volume)
    {
        Debug.Log("Volume: " + volume);
        
    }
}