using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Single_Wheel_move : MonoBehaviour
{
    [SerializeField] WheelCollider FR;
    [SerializeField] WheelCollider FL;
    [SerializeField] WheelCollider RR;
    [SerializeField] WheelCollider RL;


    public float accelaration = 500f;
    public float brakeForce = 500f;
    public float maxTurnAngle = 15f;

    public float currentAcceleration = 0f;
    private float currentBrakeForce = 0f;
    public float currentTurnAngle = 0f;


    // Update is called once per frame
    private void FixedUpdate()
    {
        currentAcceleration = accelaration *Input.GetAxis("Vertical"); //W S as move

        if (Input.GetKey(KeyCode.Space)){
            currentBrakeForce = brakeForce*30;
        }else{
            currentBrakeForce = 0f;
        }
        RR.motorTorque = currentAcceleration;
        RL.motorTorque = currentAcceleration;
        FR.motorTorque = currentAcceleration;
        FL.motorTorque = currentAcceleration;
        
        //FR.brakeTorque = currentBrakeForce;
        //FL.brakeTorque = currentBrakeForce;
        RR.brakeTorque = currentBrakeForce;
        RL.brakeTorque = currentBrakeForce;

        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        FR.steerAngle = currentTurnAngle;
        FL.steerAngle = currentTurnAngle;


    }
}
