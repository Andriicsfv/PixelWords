using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelTeleport : MonoBehaviour
{
    [Header("Налаштування")]
    public string sceneName; 
    public bool loadNextByIndex = true; 

    
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Player"))
        {
            if (loadNextByIndex)
            {
               
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

                
                if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
                {
                    SceneManager.LoadScene(nextSceneIndex);
                }
                else
                {
                    Debug.Log("No next lvl");
                }
            }
            else
            {
                
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}