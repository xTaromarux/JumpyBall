using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBallController : MonoBehaviour
{
    public static HorizontalBallController instance;

    Rigidbody2D rb;
    public float ForceJump; 
    public float ForceJumpToSides;
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
            if(Input.GetMouseButtonDown(0))
            {
                GameStarted = true;
                rb.simulated = true;
                HorizontalPipeSpowner.instance.StartSpawningPipes();
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.zero;
                TouchMove();
            }
        }
    }

    void TouchMove()
    {
        if(Input.GetMouseButton(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Move to left
            if(touchPos.x < 0)
            {
                rb.AddForce(new Vector2(0, ForceJump));
                rb.velocity = Vector2.left * ForceJumpToSides;
            }
            // Move to right
            else
            {
                rb.AddForce(new Vector2(0, ForceJump));
                rb.velocity = Vector2.right * ForceJumpToSides;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameOver = true;
        rb.gravityScale = 50;
        HorizontalGameManager.instance.GameOverGM();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Pipe" )
        {
            GameOver = true;
            rb.gravityScale = 50;
            HorizontalGameManager.instance.GameOverGM();
        }

        if(col.gameObject.tag == "ScoreChecker" && !GameOver)
        {
            ScoreManager.instance.IncrementScore();
        }
    }
}