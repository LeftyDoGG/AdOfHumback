using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
    
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0) // If the enemy and the player have health left...
        {
            nav.SetDestination (player.position); // set the destination of the nav mesh agent to the player.
        }
        else
        {
        
            nav.enabled = false; // ... disable the nav mesh agent.
        }
    }
}
