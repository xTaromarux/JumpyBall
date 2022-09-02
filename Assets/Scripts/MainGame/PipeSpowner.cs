using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpowner : MonoBehaviour
{
    public static PipeSpowner instance;

    public float MaxYPos;
    public float SpawnTime;
    public GameObject Pipes;

    private void Awake()
    {
        if(!instance){
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
    
    public void StartSpawningPipes()
    {
        InvokeRepeating("SpawnPipes", 0.2f, SpawnTime);
    } 

    public void StopSpawningPipes()
    {
        CancelInvoke("SpawnPipes");
    } 

    void SpawnPipes()
    {
        Instantiate(Pipes, new Vector2(transform.position.x, Random.Range(-MaxYPos, 1)), Quaternion.identity);
    }
}
