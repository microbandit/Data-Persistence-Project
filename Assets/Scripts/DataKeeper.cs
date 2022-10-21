using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataKeeper : MonoBehaviour
{
    public static DataKeeper Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }
    public static string topPlayer = "Kaiba";
    public static string playerName="AAA";
    public static int highScore = 9;
    // Start is called before the first frame update
    [System.Serializable]
    class SaveData
    {
        public string topPlayer;
        public int highScore;
    }
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.topPlayer = topPlayer;
        data.highScore = highScore;

        string json= JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            topPlayer= data.topPlayer;
            highScore=data.highScore;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
