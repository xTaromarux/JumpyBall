using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using TMPro;

public class LeaderBoardManager : MonoBehaviour
{
    public static LeaderBoardManager instance;
    public TextMeshProUGUI StatusTxt;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    } 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeaderBoardButton()
    {
        Social.ShowLeaderboardUI();
    }

    public void AddScoreToLeaderBoard(int score)
    {
        Social.ReportScore(score, GPGS.leaderboard_bestplayernormalmode, (bool success) => {
            if (success)
            {
                StatusTxt.text = "Success";
            }
        });
    }

    public void AddToLeaderBoardButton()
    {
        AddScoreToLeaderBoard(5);
    }
}
