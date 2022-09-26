using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectille : MonoBehaviour
{
    Rigidbody rb;
    bool isPLaying = false;
    public float speed = 10f;
    private void Start() 
    {
     rb = GetComponent<Rigidbody>();
     isPLaying = true;  
    }
    
    private void Update() 
    {
        if (isPLaying == true)
        {
            rb.velocity = Vector3.left * speed * Time.time;
            Debug.Log("moving");
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }    
    }
}
