using UnityEngine;

public class LevelManager : MonoBehaviour 
{
    

    void Start()
    {
        
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        
        GameObject spawnPoint = GameObject.Find("SpawnPoint");

        if (playerObj != null)
        {
            
            if (spawnPoint != null)
            {
                playerObj.transform.position = spawnPoint.transform.position;
            }

            
        }
        else
        {
            Debug.LogError("No tag");
        }
    }
}