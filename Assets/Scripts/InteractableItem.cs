using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [Header("ID слова з JSON файлу")]
    [SerializeField] private string _wordID;

    private bool _canInteract = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _canInteract = true;
            Debug.Log("Press E");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _canInteract = false;
            UIManager.Instance.CloseCard();
        }
    }

    private void Update()
    {
        if (_canInteract && Input.GetKeyDown(KeyCode.E))
        {
            
            WordData info = VocabularyManager.Instance.GetWord(_wordID);

            
            if (info != null)
            {
                UIManager.Instance.ShowCard(info);
            }
        }
    }
}