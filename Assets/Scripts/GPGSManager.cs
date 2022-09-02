using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using TMPro;

public class GPGSManager : MonoBehaviour
{
    public static GPGSManager instance;

    public TextMeshProUGUI StatusTxt;
    public TextMeshProUGUI DescriptionTxt;

    private void Awake()
    {
        if (!instance)
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

    public void LoginGooglePlayGames()
    {
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(OnGooglePlayGamesLogin);
    }

    public void LeaderBoardButton()
    {
        Social.ShowLeaderboardUI();
    }

    public void ShowLeaderBoard()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIgazRiMoHEAIQAQ");
    }
    
    void OnGooglePlayGamesLogin(bool success, string authCode)
    {
        if (success)
        {
            //Call Unity Authentication SDK to sign in or link with Google Play Games
            StatusTxt.text = "Login with Google Play games successful.";
            DescriptionTxt.text = "Authorization code: " + authCode;
        }
        else
        {
            StatusTxt.text = "Login Unsuccessful";
        }
    }

}