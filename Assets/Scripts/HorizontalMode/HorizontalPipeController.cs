using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPipeController : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        MovePipe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MovePipe()
    {
        rb.velocity = new Vector2(0, -Speed);
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "PipeRemover")
        {
            Destroy(gameObject);
        }
    }
}
