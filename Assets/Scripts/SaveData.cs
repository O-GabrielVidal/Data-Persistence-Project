using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour
{
    public static SaveData Instance;

    public int points=0;
    public string nameOfPlayer;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPoints();
    }

    [System.Serializable]
    class DataofBestScore
    {
        public int points;
        public string nameOfPlayer;
    }

    public void EnterName(string name)
    {
        nameOfPlayer = name;
    }

    public void SavePoints(int p)
    {
        DataofBestScore bs= new DataofBestScore();
        bs.points = p;
        points=bs.points;
        bs.nameOfPlayer = nameOfPlayer;

        string json=JsonUtility.ToJson(bs);

        File.WriteAllText(Application.persistentDataPath + "/save2file.json", json);
    }

    public void LoadPoints()
    {
        string path = Application.persistentDataPath + "/save2file.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            DataofBestScore bs=JsonUtility.FromJson<DataofBestScore>(json);

            points = bs.points;
            nameOfPlayer = bs.nameOfPlayer;
        }
    }
}
