using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int Score;

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
    } 

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        PlayerPrefs.SetInt("Score", Score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore()
    {
        Score++;
    }

    public void StopScore()
    {
        PlayerPrefs.SetInt("Score", Score);

        if(SceneManager.GetActiveScene().buildIndex == 1){
            if(PlayerPrefs.HasKey("HighScore"))
            {
                if(Score > PlayerPrefs.GetInt("HighScore"))
                {
                    PlayerPrefs.SetInt("HighScore", Score);
                }
            }
            else
            {
                PlayerPrefs.SetInt("HighScore", Score);
            }
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2){
            if(PlayerPrefs.HasKey("HorizontalHighScore"))
            {
                if(Score > PlayerPrefs.GetInt("HorizontalHighScore"))
                {
                    PlayerPrefs.SetInt("HorizontalHighScore", Score);
                }
            }
            else
            {
                PlayerPrefs.SetInt("HorizontalHighScore", Score);
            }
        }
    }
}
