using UnityEngine;
using TMPro;            
using UnityEngine.UI;   

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("--- Õ¿¬◊¿À‹Õ¿  ¿–“ ¿ (—ÎÓ‚‡) ---")]
    [SerializeField] private GameObject _learningPanel;
    [SerializeField] private TextMeshProUGUI _englishTextObj;   
    [SerializeField] private TextMeshProUGUI _ukrainianTextObj; 
    [SerializeField] private Image _itemImageObj;

    [Header("--- ƒ≤¿ÀŒ√ (NPC) ---")]
    [SerializeField] private GameObject _dialoguePanel;      
    [SerializeField] private TextMeshProUGUI _dialogueText;  
    [SerializeField] private TextMeshProUGUI _nameText;      
    [SerializeField] private Image _portraitImage;           

    private void Awake()
    {
        
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        
        _learningPanel.SetActive(false);
        _dialoguePanel.SetActive(false);
    }

   
    public void ShowCard(WordData data)
    {
        _learningPanel.SetActive(true);
        _dialoguePanel.SetActive(false); 

        
        _englishTextObj.text = data.polishWord;
        _ukrainianTextObj.text = data.englishTranslation;

        if (data.spriteName != "")
        {
            Sprite art = Resources.Load<Sprite>(data.spriteName);
            if (art != null)
            {
                _itemImageObj.sprite = art;
                _itemImageObj.gameObject.SetActive(true);
            }
            else
            {
                _itemImageObj.gameObject.SetActive(false);
            }
        }
    }

    
    public void ShowDialogue(string text, Sprite faceSprite, string name)
    {
        _dialoguePanel.SetActive(true);
        _learningPanel.SetActive(false); 

        
        _dialogueText.text = text;

        
        _nameText.text = name;

        
        if (faceSprite != null)
        {
            _portraitImage.sprite = faceSprite;
            _portraitImage.gameObject.SetActive(true);
        }
        else
        {
            
            _portraitImage.gameObject.SetActive(false);
        }
    }

    
    public void CloseDialogue()
    {
        _dialoguePanel.SetActive(false);
    }

    public void CloseCard()
    {
        _learningPanel.SetActive(false);
    }

    
    public void CloseAll()
    {
        _learningPanel.SetActive(false);
        _dialoguePanel.SetActive(false);
    }
}