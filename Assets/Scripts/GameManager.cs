using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
