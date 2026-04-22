using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [SerializeField] private string _wordID; 
    private bool _canInteract = false;

    private void Update()
    {
        
        if (_canInteract && Input.GetKeyDown(KeyCode.E))
        {
            if (VocabularyManager.Instance == null) return;

            WordData info = VocabularyManager.Instance.GetWord(_wordID);

            if (info != null)
            {
                
                if (QuizManager.Instance != null)
                {
                    QuizManager.Instance.OpenQuiz(info);
                }
                
                else if (UIManager.Instance != null)
                {
                    UIManager.Instance.ShowCard(info);
                    if (ShopManager.Instance != null) ShopManager.Instance.TryCollectItem(_wordID);
                }
            }
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _canInteract = true;
            Debug.Log($"ֳנאגוצü ן³ה³ירמג המ {_wordID}");
        }
    }

    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _canInteract = false;
            Debug.Log($"ֳנאגוצü ג³ה³ירמג ג³ה {_wordID}");

            
            if (UIManager.Instance != null)
            {
                UIManager.Instance.HideCard();
            }

            
            if (QuizManager.Instance != null)
            {
                QuizManager.Instance.CloseQuiz();
            }
        }
    }
}