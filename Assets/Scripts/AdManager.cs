using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    public static AdManager instance;
    string GameID = "4906447";

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
        Advertisement.Initialize(GameID);

        Advertisement.AddListener(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Show Ads 
    public void ShowAd()
    {
        if(PlayerPrefs.HasKey("AdCount"))
        {
            if(PlayerPrefs.GetInt("AdCount") == 4){
                if(Advertisement.IsReady("Rewarded_Android"))
                {
                    Advertisement.Show("Rewarded_Android");
                }
                PlayerPrefs.SetInt("AdCount", 0);
            }
            else
            {
                PlayerPrefs.SetInt("AdCount", PlayerPrefs.GetInt("AdCount") + 1);
            }
        }
        else
        {
            PlayerPrefs.SetInt("AdCount", 0);
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string PlacementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {

        if(showResult == ShowResult.Finished)
        {
            // Reward the User
            print("REWARD");
        }
        else if(showResult == ShowResult.Skipped)
        {
            // No Reward the User
            print("NO REWARD");
        }
    }
}
