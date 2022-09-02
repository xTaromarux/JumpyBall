using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float Speed;
    public float UpDownSpeed;
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

    void SwitchUpDown()
    {
        UpDownSpeed = -UpDownSpeed;
        rb.velocity = new Vector2(Speed, UpDownSpeed);
    }

    void MovePipe()
    {
        rb.velocity = new Vector2(-Speed, 0);
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "PipeRemover")
        {
            Destroy(gameObject);
        }
    }
}
