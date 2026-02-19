using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [Header("Панелі")]
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _settingsPanel;

    [Header("Елементи Налаштувань")]
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Toggle _fullscreenToggle;

    private void Start()
    {
        
        float savedVolume = PlayerPrefs.GetFloat("volume", 1f);
        _volumeSlider.value = savedVolume;
        AudioListener.volume = savedVolume;

        bool isFullscreen = PlayerPrefs.GetInt("fullscreen", 1) == 1;
        _fullscreenToggle.isOn = isFullscreen;
        Screen.fullScreen = isFullscreen;

        
        if (_mainMenuPanel != null) _mainMenuPanel.SetActive(true);
        _settingsPanel.SetActive(false);
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_settingsPanel.activeSelf)
                CloseSettings();
            else
                OpenSettings();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenSettings()
    {
        _settingsPanel.SetActive(true); 
    }

    public void CloseSettings()
    {
        _settingsPanel.SetActive(false);
        PlayerPrefs.Save();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("volume", volume);
    }


    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame()
    {
        Debug.Log("Вихід!");
        Application.Quit();
    }
}