using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class MenuUIManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void PlayHorizontalMode()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        SceneManager.LoadScene(2);
    }

    /*public void SignInButton()
    {
        PlayGamesPlatform.Instance.ManuallyAuthenticate(GPGSManager.instance.ProcessAuthentication);
    }

    public void LeaderBoardButton()
    {
        Social.ShowLeaderboardUI();
    }*/

    public void SignOutButton()
    {
        //PlayGamesPlatform.Instance.SignOut();
        GPGSManager.instance.StatusTxt.text = "Sign Out";
        GPGSManager.instance.DescriptionTxt.text = "";
    }
}
