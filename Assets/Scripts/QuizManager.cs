using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance;

    [Header("UI Елементи")]
    [SerializeField] private GameObject _quizPanel;      
    [SerializeField] private TextMeshProUGUI _polishWordText;
    [SerializeField] private Button[] _answerButtons;

    private WordData _currentWord;

    void Awake()
    {
        Instance = this;

        
        if (_quizPanel != null)
            _quizPanel.SetActive(false);
    }

    public void OpenQuiz(WordData data)
    {
        if (data == null) return;

        _currentWord = data;

        
        _quizPanel.SetActive(true);

        
        Time.timeScale = 0f;

        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        
        _polishWordText.text = data.polishWord;

       
        List<string> options = PrepareOptions(data.englishTranslation);

        for (int i = 0; i < _answerButtons.Length; i++)
        {
            int index = i;
            _answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = options[i];

            _answerButtons[i].onClick.RemoveAllListeners();
            _answerButtons[i].onClick.AddListener(() => OnClickAnswer(options[index]));
        }
    }

    private List<string> PrepareOptions(string correct)
    {
        List<string> options = new List<string> { correct };
        List<WordData> allWords = VocabularyManager.Instance.GetAllWords();

        
        int safetyNet = 0;
        while (options.Count < _answerButtons.Length && safetyNet < 100)
        {
            safetyNet++;
            string randomEng = allWords[Random.Range(0, allWords.Count)].englishTranslation;
            if (!options.Contains(randomEng))
            {
                options.Add(randomEng);
            }
        }

        
        for (int i = 0; i < options.Count; i++)
        {
            string temp = options[i];
            int randomIndex = Random.Range(i, options.Count);
            options[i] = options[randomIndex];
            options[randomIndex] = temp;
        }
        return options;
    }

    public void OnClickAnswer(string chosen)
    {
        if (chosen == _currentWord.englishTranslation)
        {
            Debug.Log("<color=green>ПРАВИЛЬНО!</color>");

            
            if (ShopManager.Instance != null)
                ShopManager.Instance.TryCollectItem(_currentWord.id);

            CloseQuiz();
        }
        else
        {
            Debug.Log("<color=red>ПОМИЛКА!</color> Спробуй ще раз.");
            
        }
    }

    public void CloseQuiz()
    {
        
        _quizPanel.SetActive(false);

        
        Time.timeScale = 1f;

        
    }
}