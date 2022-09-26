using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public SerialController serialController;
    static public Player player;
    Animator anim;
    Rigidbody rb;
    public float jumpSpeed = 5;
    public bool gameOver = false;

    public string[] strArr = new string[2];
    public int lastButtonVal;
    void Start()
    {
        gameOver = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        player = this;
    }
    void FixedUpdate()
    {
        string message = serialController.ReadSerialMessage();

        if (message == null)
            return;

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");

        
        strArr = message.Split(',');      
        int pot = int.Parse(strArr[0]);
        int buttonVal = int.Parse(strArr[1]);
        Vector3 pos = transform.position;
        //pos.z = pot;
        transform.Translate(Vector3.right * pot * Time.deltaTime);
        anim.SetFloat("blend", 0);
       
        if(buttonVal == 0)
        { 
            buttonVal = 0;
            lastButtonVal = buttonVal;
            anim.SetBool("jump", false);   
            return;
        }
        if (buttonVal == 1)
        {
            lastButtonVal = buttonVal;
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            serialController.SendSerialMessage("A");
            anim.SetBool("jump", true);
        }
        buttonVal = 0;   
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Obstacle")
        {
            gameOver = true;
            Debug.Log("GameOVER");
            Destroy(this.gameObject);
        }    
    }
}
