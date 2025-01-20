using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Enemy1Movepattern TargetScript;
    public Camera cam;
    void Update()
 {
        //Check for mouse click 
        if (Input.GetMouseButtonDown(0))
        {
            LayerMask mask = 2;
            RaycastHit raycastHit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 10000f, mask))
            {
                if (raycastHit.transform != null)
                {
                   //Our custom method. 
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }
 }

public void CurrentClickedGameObject(GameObject gameObject)
{
    if(gameObject.tag=="Enemy")
    {
        TargetScript.TakeDamage(10);
    }
}
}
