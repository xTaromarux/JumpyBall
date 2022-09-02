using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GameOverScoreText;
    public TextMeshProUGUI HighScoreText;
    public GameObject GameOverPanel;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = ScoreManager.instance.Score.ToString();
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        ScoreText.GetComponent<Animator>().Play("ScoreTextAnim");
        ScoreText.enabled = false;
        if(SceneManager.GetActiveScene().buildIndex == 1){
            HighScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
            GameOverScoreText.text = PlayerPrefs.GetInt("Score").ToString();
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2){
            HighScoreText.text = PlayerPrefs.GetInt("HorizontalHighScore").ToString();
            GameOverScoreText.text = PlayerPrefs.GetInt("Score").ToString();
        }
    }

    public void ReplayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuButton()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.LoadScene("Menu");
    }
}
