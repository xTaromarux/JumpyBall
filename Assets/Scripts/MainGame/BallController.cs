using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController instance;

    Rigidbody2D rb;
    public float ForceJump; 
    bool GameStarted;
    public bool GameOver;

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
        
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameStarted = false;
        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameStarted)
        {
            // windows detect click -> if(Input.GetMouseButtonDown(0))
            // Android Device detect touch if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            if(Input.GetMouseButtonDown(0))
            {
                GameStarted = true;
                rb.simulated = true;
                PipeSpowner.instance.StartSpawningPipes();
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, ForceJump));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameOver = true;
        rb.gravityScale = 20;
        GameManager.instance.GameOverGM();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Pipe" )
        {
            GameOver = true;
            rb.gravityScale = 20;
            GameManager.instance.GameOverGM();
        }

        if(col.gameObject.tag == "ScoreChecker" && !GameOver)
        {
            ScoreManager.instance.IncrementScore();
        }
    }
}