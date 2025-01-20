using System.Collections;
using System.Collections.Generic;
using System.Xml;
//using UnityEditor.Callbacks;
using UnityEngine;

public class Basic_Movement : MonoBehaviour
{
    Rigidbody Rg; //setting up physics 
    // Start is called before the first frame update

    public float accelaration;
    public float MaxSpeed;
    public float Handling;
    private float horizontalInput; //Horizontal and Forward input are taken directly from unity settings, change those there
    private float forwardIput;
    private bool OnTheGround = false;
  
    
    void Start()
    {
        Rg = GetComponent<Rigidbody>() ; // setting Rg as pointer to Rigidbody settings
        Rg.freezeRotation = false; //allows the rotation to be affected by physics
    }
  
    // Update is called once per frame
    void OnCollisionStay(){
        OnTheGround = true;
        if (OnTheGround){
        //Getting player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardIput = Input.GetAxis("Vertical");

        //Basic Movement
        transform.Translate(Vector3.forward * Time.deltaTime * MaxSpeed * forwardIput); //Vector3.forward gives it direction, time listens for held input
        transform. Rotate(Vector3.up, Handling * horizontalInput, Space.Self); //Space.self makes the rotation relative to the car, handling * horizontal input makes the car turn left or right at a variable rate
        }
        else{
            transform.Translate(Vector3.forward * Time.deltaTime * Rg.velocity.magnitude);
        }
    }
    void Update()
    {
        if (OnTheGround){
        //Getting player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardIput = Input.GetAxis("Vertical");

        //Basic Movement
        transform.Translate(Vector3.forward * Time.deltaTime * MaxSpeed * forwardIput); //Vector3.forward gives it direction, time listens for held input
        transform. Rotate(Vector3.up, Handling * horizontalInput, Space.Self); //Space.self makes the rotation relative to the car, handling * horizontal input makes the car turn left or right at a variable rate
        }
        else{
            transform.Translate(Vector3.forward * Time.deltaTime * Rg.velocity.magnitude);
        }
    }
    void OnCollisionExit(){
        //OnTheGround = false;
    }
}
