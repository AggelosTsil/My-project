using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestruction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionStay(Collision impact){
        if (impact.gameObject.tag != "Enemy"){
            Destroy (gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
