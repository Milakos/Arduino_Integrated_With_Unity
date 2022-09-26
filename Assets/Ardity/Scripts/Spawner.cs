using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    Player pl;
    public GameObject[] rb;
    float minPos = -8f;
    float maxPos = 8f;
    float xPos = 220;
    public float speed = 10;

    public float spawnTime = 2f;

    float destoryNumber = -14f;

    private void Awake() 
    {
        pl = FindObjectOfType<Player>();
       // rb = FindObjectOfType<GameObject>();
    }
    private void Start() 
    {
        if(pl.gameOver == false)
        {
           StartCoroutine(waitAndSpawn(spawnTime));
        }
    }

    private void Update() 
    {
        if (pl.gameOver == true)
        {
            StopAllCoroutines();
        }    
    }

    public IEnumerator waitAndSpawn(float waitTime)
    {
        while (true)
        {
        var positions = new Vector3(xPos,0.5f,Random.Range(minPos, maxPos));
        Instantiate(rb[Random.Range(0, rb.Length)], positions, transform.rotation);  
        yield return new WaitForSeconds(waitTime); 
        }
    }

}
