using UnityEngine;

[System.Serializable]
public class WordData
{
    public string id; 
    public string polishWord; 
    public string englishTranslation; 
    public string spriteName; 

    
    [System.NonSerialized] public Sprite itemSprite;
}

[System.Serializable]
public class WordList
{
    public WordData[] words;
}