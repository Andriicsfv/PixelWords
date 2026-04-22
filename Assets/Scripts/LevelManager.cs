using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string homePointName = "SpawnHome";
    public string shopPointName = "SpawnShop";

    void Awake()
    {
        
        SetupPosition();
    }

    void SetupPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        
        int fromShop = PlayerPrefs.GetInt("SpawnAtShop", 0);

        
        string targetName = (fromShop == 1) ? shopPointName : homePointName;
        GameObject targetPoint = GameObject.Find(targetName);

        if (targetPoint != null)
        {
            
            player.transform.position = targetPoint.transform.position;

            
            if (Camera.main != null)
            {
                Vector3 camPos = targetPoint.transform.position;
                camPos.z = Camera.main.transform.position.z;
                Camera.main.transform.position = camPos;
            }
        }

        
        PlayerPrefs.SetInt("SpawnAtShop", 0);
        PlayerPrefs.Save();
    }
}