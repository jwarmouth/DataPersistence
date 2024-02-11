using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistentData : MonoBehaviour
{
    public static PersistentData Instance;
    public string playerName;
    public string hiScoreName;
    public int hiScore;

    // Start is called before the first frame update
    void Awake()
    {
        if (PersistentData.Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }

    public void SaveScore(int score)
    {
        hiScoreName = playerName;
        hiScore = score;

        SaveData data = new SaveData();
        data.name = playerName;
        data.score = score;

        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "hiscore.json";
        File.WriteAllText(path, json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "hiscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            hiScoreName = data.name;
            hiScore = data.score;
        }
    }
}
