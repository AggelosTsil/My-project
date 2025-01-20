using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class drift : MonoBehaviour
{
    private Quaternion startingRot; //the starting rotation quaternion
    public float DriftRate = 0.5f;
    private float CurrentDriftRate;
    public Camera normalCamera;
    public Camera driftCamera;
    // Start is called before the first frame update
    void Start()
    {
        startingRot = transform.rotation; //saves the starting rotation
        driftCamera.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)){
            
            transform.Rotate(0, DriftRate * Input.GetAxis("Horizontal"), 0);
            SwitchCameras();
            
        }
        else if (Input.GetKeyUp(KeyCode.Space)){
            transform.rotation = startingRot;
            SwitchCameras();
        }
        
    }
    void FixedUpdate(){
        startingRot = transform.rotation;   
    }
    void SwitchCameras(){
        normalCamera.enabled = !normalCamera.enabled;
        driftCamera.enabled = !driftCamera.enabled;
    }
}

