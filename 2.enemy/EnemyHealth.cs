using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int currentHealth;
    public int scoreValue = 10;


    //public int expValue = 10;
    //public int startingEXP = 0;
    //public int currentExp;
    //public Slider ExpSlider;

    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;

    bool isDead;

    

    void Awake ()
    {
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();
        currentHealth = MaxHealth;
        //currentExp = startingEXP;

    }

    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead) // If the enemy is dead...
            return;

        currentHealth -= amount;  // Reduce the current health by the amount of damage sustained.
        
        if(currentHealth <= -0) // If the current health is less than or equal to zero.
        {

            Death(); // enemy is dead.
            
        }
    }
    
    void Death ()
    {
        isDead = true; // The enemy is dead.
        Destroy(gameObject);
        ScoreManager.score += scoreValue; // increase score bar value.

        //currentExp += expValue;
        //ExpSlider.value = currentExp;

    }

}
