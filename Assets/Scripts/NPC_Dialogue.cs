using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    [Header("Налаштування Персонажа")]
    public string npcName = "Marek";  

    [TextArea]
    public string message = "Привіт! Я допоможу тобі вивчити мову."; 

    public Sprite npcFace; 

    private bool _isPlayerNear = false;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerNear = true;
        }
    }

   
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerNear = false;
            UIManager.Instance.CloseDialogue(); 
        }
    }

    private void Update()
    {
        
        if (_isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            
            UIManager.Instance.ShowDialogue(message, npcFace, npcName);
        }
    }
}