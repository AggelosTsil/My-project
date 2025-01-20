using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        curHealth= maxHealth;
    }

    void OnCollisionEnter(Collision hit){
        if (hit.gameObject.tag == "IncomingDamage"){
            DamagePlayer(10);
            if (curHealth <= 0){
                SceneManager.LoadScene("Backup");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void DamagePlayer(int damage){
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
    }
     private void DestroyEnemy(){
        //Instantiate(explosion, gameObject.transform ,0 );
        Destroy (gameObject);
    }
}
