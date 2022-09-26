using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
        //Public variable to store a reference to the player game object
    public Transform rot;
    public float turnSpeed = 40f;

    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
       offset = new Vector3(rot.position.x, rot.position.y, rot.position.z + 7.0f);
    }

    // LateUpdate is called after Update each frame
    void Update () 
    {
        offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
         transform.position = rot.position + offset; 
         transform.LookAt(rot.position);

        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
  }
     
