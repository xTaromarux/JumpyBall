using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOverGM()
    {
        ScoreManager.instance.StopScore();
        UIManager.instance.GameOver();
        PipeSpowner.instance.StopSpawningPipes();
        //AdManager.instance.ShowAd();
        //LeaderBoardManager.instance.AddScoreToLeaderBoard(ScoreManager.instance.Score);
    } 
}
