using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject deathlight;
    public Vector3 position;
    private GameObject Temp;
    [SerializeField]
    [Range(0,3)]
    public float TimeOfLife; 
    public Light Light;
    // Start is called before the first frame update
    void Start()
    {
        Light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
       Light.range += 1;
       if (Light.range > 55){
        Light.range = 10;
       }
    }
    public void BlowUp(Vector3 position){
         Temp = Instantiate(deathlight, position ,quaternion.identity );
         Invoke(nameof(EndExplosion), TimeOfLife);
    }
    void EndExplosion(){
        Destroy (Temp);
    }
}
