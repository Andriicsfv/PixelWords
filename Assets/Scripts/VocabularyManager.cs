using UnityEngine;

public class VocabularyManager : MonoBehaviour
{
    
    public static VocabularyManager Instance;

    [Header("Файл з базою слів (.json)")]
    [SerializeField] private TextAsset _jsonDatabaseFile;

    private WordList _loadedWords;

    private void Awake()
    {
        
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        LoadData();
    }

    private void LoadData()
    {
        if (_jsonDatabaseFile != null)
        {
            
            _loadedWords = JsonUtility.FromJson<WordList>(_jsonDatabaseFile.text);
        }
        else
        {
            Debug.LogError("Помилка! Забув прикріпити JSON файл в інспекторі!");
        }
    }

    
    public WordData GetWord(string searchID)
    {
        foreach (var word in _loadedWords.words)
        {
            if (word.id == searchID) return word;
        }
        return null; 
    }
}