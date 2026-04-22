using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private string _streetSceneName = "Outside"; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (ShopManager.Instance != null && ShopManager.Instance.shoppingListIDs.Count == 0)
            {
                
                PlayerPrefs.SetInt("SpawnAtShop", 1);
                SceneManager.LoadScene(_streetSceneName);
            }
            else
            {
                
                UIManager.Instance.ShowDialogue("List is not Empty", null, "Я");
            }
        }
    }
}