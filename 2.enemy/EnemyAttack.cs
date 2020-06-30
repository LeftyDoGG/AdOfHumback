using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f; // The time in seconds between each attack.
    public int attackDamage = 10; // The amount of health taken away per attack.


    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player) // If the entering collider is the player...
        {
            playerInRange = true; // ... the player is in range.
        }
    }


    void OnTriggerExit (Collider other)
    { 
        if(other.gameObject == player) // If the exiting collider is the player...
        {
            playerInRange = false;  // the player is no longer in range.
        }
    }


    void Update ()
    {
        timer += Time.deltaTime; // Add the time since Update was last called to the timer.

        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0) // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        {
            Attack (); // attack.
        }
    }


    void Attack ()
    {
        timer = 0f; // Reset the timer.

        if(playerHealth.currentHealth > 0) // If the player has health to lose.
        {
            playerHealth.TakeDamage (attackDamage); // damage the player.
        }
    }
}
