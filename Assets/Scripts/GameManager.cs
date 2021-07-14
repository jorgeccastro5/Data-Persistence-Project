using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string player;
    public string playerBestScore;
    public int bestScore;
    
    private string savefile;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        savefile = Application.persistentDataPath + "/savefile.json";
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int bestScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.playerName = player;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(savefile, json);
    }

    public void LoadScore()
    {
        if (File.Exists(savefile)) 
        {
            string json = File.ReadAllText(savefile);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerBestScore = data.playerName;
            bestScore = data.bestScore;
        }
    }
}
