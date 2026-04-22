using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTeleport : MonoBehaviour
{
    public string sceneName; 
    public bool requireEmptyList = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (requireEmptyList)
            {
                if (ShopManager.Instance != null && ShopManager.Instance.shoppingListIDs.Count > 0)
                {
                    Debug.Log("Купи все спочатку!");
                    return;
                }

                
                PlayerPrefs.SetInt("SpawnAtShop", 1);
                PlayerPrefs.Save();
            }

            SceneManager.LoadScene(sceneName);
        }
    }
}