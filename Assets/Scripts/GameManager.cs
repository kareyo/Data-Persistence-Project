using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string playerName;
    public int[] highscore;
    public string[] highestScorer;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            highscore = new int[3] {0, 0, 0 };
            highestScorer = new string[3] { "-", "-", "-" };
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
        public string name0;
        public int score0;
        public string name1;
        public int score1;
        public string name2;
        public int score2;
    }

    public void SaveHighscore()
    {
        Highscore savedScore = new Highscore();
        savedScore.score0 = highscore[0];
        savedScore.name0 = highestScorer[0];
        savedScore.score1 = highscore[1];
        savedScore.name1 = highestScorer[1];
        savedScore.score2 = highscore[2];
        savedScore.name2 = highestScorer[2];

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

            highscore[0] = savedScore.score0;
            highestScorer[0] = savedScore.name0;
            highscore[1] = savedScore.score1;
            highestScorer[1] = savedScore.name1;
            highscore[2] = savedScore.score2;
            highestScorer[2] = savedScore.name2;
        }

    }

}
