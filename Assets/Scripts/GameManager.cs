using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string playerName;
    public int highscore;
    public string highestScorer;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            highscore = 0;
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class Highscore
    {
        public string name;
        public int score;
    }

    public void SaveHighscore()
    {
        Highscore savedScore = new Highscore();
        savedScore.score = highscore;
        savedScore.name = highestScorer;
        
        string json = JsonUtility.ToJson(savedScore);

        File.WriteAllText(Application.persistentDataPath + "/brickgame_savefile.json", json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/brickgame_savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Highscore savedScore = JsonUtility.FromJson<Highscore>(json);

            highscore = savedScore.score;
            highestScorer = savedScore.name;
        }

    }

}
