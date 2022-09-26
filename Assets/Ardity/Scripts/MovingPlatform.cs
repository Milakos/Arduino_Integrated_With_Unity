using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    Player pl;
    public float endPoind = -14f;
    public float startPoint = 14f;
    public float speed = 10f;
    public GameObject platform;

    private void Awake() 
    {
        pl = FindObjectOfType<Player>();    
    }
    void FixedUpdate()
    {
        Vector3 startPos = new Vector3(startPoint, transform.position.y, transform.position.z);
        Vector3 endPos = new Vector3(endPoind, transform.position.y, transform.position.z);

        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if(transform.localPosition.x <= endPoind)
        {
            Debug.Log("reached");
            transform.position = startPos;
        }

        if (pl.gameOver == true)
        {
            Destroy(this);
        }
    }
}
