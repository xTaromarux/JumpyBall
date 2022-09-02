using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalGameManager : MonoBehaviour
{
    public static HorizontalGameManager instance;

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
        HorizontalPipeSpowner.instance.StopSpawningPipes();
        //AdManager.instance.ShowAd();
    } 
}
