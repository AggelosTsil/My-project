using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Camera : MonoBehaviour
{
    public GameObject player;
	public float sensitivity = 500.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0)
       {
            float verticalInput = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
            float horizontalInput = Input.GetAxis("Mouse X") * sensitivity *Time.deltaTime;
            transform.Rotate(Vector3.up, verticalInput);
            transform.Rotate(Vector3.right, horizontalInput, Space.World);
       }
    }
}
