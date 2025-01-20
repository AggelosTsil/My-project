using System.Collections;
using System.Collections.Generic;
//using Microsoft.Unity.VisualStudio.Editor;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
public class Enemy1Movepattern : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, WhatIsPlayer;
    public float health;
   // public Explosion explosion;
    public float ForceForward;
    public float ForceUp;
    //patrol
    public Vector3 walkPoint;
    public GameObject Projectile;
    bool walkPointSet;
    public float walkPointRange;
    private Vector3 BulletSpawnPoint;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public float BSx;
    public float BSy;
    public float BSz;
    private GameObject TempExp;
    public GameObject deathlight;
    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake(){
        player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void OnMouseDown()
    {
        TakeDamage(3);
    }
   // private void Patroling(){
       // if (!walkPointSet) SearchWalkPoint();

       // if (walkPointSet)
          //  agent.SetDestination(walkPoint);

       // Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached ig idk
      //  if (distanceToWalkPoint.magnitude < 10f)
          //  walkPointSet = false;
    //private void SearchWalkPoint(){
        //float randomZ = Random.Range(-walkPointRange, walkPointRange);
        //float randomY = Random.Range(-walkPointRange, walkPointRange);
        //float randomX = Random.Range(-walkPointRange, walkPointRange);

        //walkPoint = new Vector3(transform.position.x +randomX, transform.position.y +randomY , transform.position.z +randomZ);

       // if (Physics.Raycast(walkPoint, -transform.up, 20f, whatIsGround))
            //walkPointSet = true;
    //}
    private void ChasePlayer(){
        agent.SetDestination(player.position);
        //agent.SetDestination(transform.position);
    }
    private void AttackPlayer(){
        //agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked){
            BulletSpawnPoint = new Vector3(transform.position.x +BSx, transform.position.y + BSy, transform.position.z+ BSz);
            GameObject newCannonBall = Instantiate(Projectile, BulletSpawnPoint , Quaternion.identity);
            
            Rigidbody rb = newCannonBall.GetComponent<Rigidbody>();
            if (rb!= null){
                rb.AddForce(transform.forward * ForceForward);
                rb.AddForce(transform.up * ForceUp);
            }
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack(){
        alreadyAttacked = false;
    }
    public void TakeDamage(int damage){
        health -= damage;
        if (health <= 0) 
            Invoke(nameof(DestroyEnemy), .1f );
            //TempExp = Instantiate(deathlight, gameObject.transform.position ,quaternion.identity );
            //Invoke(nameof(Deathlight), 20000f);
        
    }
    
    private void DestroyEnemy(){
        Destroy (gameObject);
        FindAnyObjectByType<Explosion>().BlowUp(BulletSpawnPoint);
        //Deathlight();
    }
    private void Deathlight(){
        //Destroy (TempExp);
    }

    // Start is called before the first frame update
    void Start()
    {
        health =  10;
    }

    // Update is called once per frame
    void Update()
    {
        
        //check los and range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);

        //if (!playerInSightRange && !playerInAttackRange) {Patroling();}
        if (playerInSightRange && !playerInAttackRange) {ChasePlayer();}
        if (playerInSightRange && playerInAttackRange) {AttackPlayer();}
    }
    
}
