using UnityEngine;

[System.Serializable]
public class WordData
{
    public string id;

   
    public string polishWord;
    public string englishTranslation;

    public string spriteName;
}

[System.Serializable]
public class WordList
{
    public WordData[] words;
}