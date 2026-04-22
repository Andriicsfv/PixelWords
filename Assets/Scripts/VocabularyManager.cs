using UnityEngine;
using System.Collections.Generic;

public class VocabularyManager : MonoBehaviour
{
    public static VocabularyManager Instance;

    [Header("Налаштування файлів")]
    [SerializeField] private TextAsset _jsonDatabaseFile;
    [SerializeField] private string _sheetPath = "Items/AllItems";

    private WordList _loadedWords;
    private Sprite[] _allSprites;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }

        LoadData();
    }

    private void LoadData()
    {
        if (_jsonDatabaseFile == null) return;

        
        _loadedWords = JsonUtility.FromJson<WordList>(_jsonDatabaseFile.text);
        _allSprites = Resources.LoadAll<Sprite>(_sheetPath);

        if (_loadedWords != null && _loadedWords.words != null)
        {
            foreach (WordData word in _loadedWords.words)
            {
                if (!string.IsNullOrEmpty(word.spriteName))
                {
                    word.itemSprite = FindSpriteInArray(word.spriteName);
                }
            }
        }
        Debug.Log("<color=cyan>VocabularyManager:</color> Базу завантажено успішно!");
    }

    private Sprite FindSpriteInArray(string spriteName)
    {
        if (_allSprites == null) return null;
        foreach (Sprite s in _allSprites)
        {
            if (s.name == spriteName) return s;
        }
        return null;
    }

    public WordData GetWord(string searchID)
    {
        if (_loadedWords == null || _loadedWords.words == null) return null;

        
        foreach (var word in _loadedWords.words)
        {
            if (word.id == searchID) return word;
        }
        return null;
    }

    
    public List<WordData> GetAllWords()
    {
        if (_loadedWords == null || _loadedWords.words == null) return new List<WordData>();

        
        return new List<WordData>(_loadedWords.words);
    }
}