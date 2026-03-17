using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;
    [Header("UI Панель списку")]
    [SerializeField] private GameObject _shoppingListPanel;

    [Header("Налаштування дня")]
    public bool isFirstDayWithFriend = true; 

    [Header("Список покупок (ID з JSON)")]
    public List<string> shoppingListIDs = new List<string>();

    [Header("UI Елементи")]
    public TextMeshProUGUI listText;
    public void ToggleList()
    {
        if (_shoppingListPanel != null)
        {
            
            bool isActive = _shoppingListPanel.activeSelf;
            _shoppingListPanel.SetActive(!isActive);
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateShoppingListUI();
    }

    public void TryCollectItem(string itemID)
    {
        if (shoppingListIDs.Contains(itemID))
        {
            shoppingListIDs.Remove(itemID);
            Debug.Log("Предмет " + itemID + " викреслено зі списку!");
            UpdateShoppingListUI();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ToggleList();
        }
    }

    private void UpdateShoppingListUI()
    {
        if (listText == null) return;

        listText.text = "Що потрібно купити:\n";

        foreach (string id in shoppingListIDs)
        {
            
            WordData data = VocabularyManager.Instance.GetWord(id);
            if (data != null)
            {
                
                listText.text += "- " + data.englishTranslation + "\n";
            }
        }

        if (shoppingListIDs.Count == 0)
        {
            listText.text = "Список порожній! Можна йти на касу.";
        }
    }
}
