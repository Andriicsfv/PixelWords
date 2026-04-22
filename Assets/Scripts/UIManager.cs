using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    public void CloseDialogue() => _dialoguePanel.SetActive(false);

    [Header("--- НАВЧАЛЬНА КАРТКА (Слова) ---")]
    [SerializeField] private GameObject _learningPanel;
    [SerializeField] private TextMeshProUGUI _polishTextUI;
    [SerializeField] private TextMeshProUGUI _englishTextUI;
    [SerializeField] private Image _itemImageUI;

    [Header("--- ДІАЛОГ (NPC) ---")]
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Image _portraitImage;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        CloseAll();
    }

    public void ShowCard(WordData info)
    {
        if (info == null) return;

        _learningPanel.SetActive(true);
        _dialoguePanel.SetActive(false);

        
        _polishTextUI.text = info.polishWord;

        
        bool showEnglish = (ShopManager.Instance != null && ShopManager.Instance.isFirstDayWithFriend);

        if (showEnglish)
        {
            _englishTextUI.text = info.englishTranslation;
            _englishTextUI.gameObject.SetActive(true);
        }
        else
        {
            _englishTextUI.gameObject.SetActive(false);
        }

        if (info.itemSprite != null)
        {
            Debug.Log($"UIManager: Спрайт для {info.id} знайдено! Назва: {info.itemSprite.name}");
        }
        else
        {
            Debug.LogWarning($"UIManager: У об'єкта {info.id} НЕМАЄ спрайта (null)!");
        }

        if (_itemImageUI != null)
        {
            if (info.itemSprite != null)
            {
                _itemImageUI.sprite = info.itemSprite;
                _itemImageUI.gameObject.SetActive(true);
            }
            else _itemImageUI.gameObject.SetActive(false);
        }

    }

    public void HideCard()
    {
        if (_learningPanel != null)
            _learningPanel.SetActive(false);
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
        else _portraitImage.gameObject.SetActive(false);
    }

    public void CloseAll()
    {
        _learningPanel.SetActive(false);
        _dialoguePanel.SetActive(false);
    }
}