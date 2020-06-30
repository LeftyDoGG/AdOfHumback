using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public int expValue = 10;
    public int startingEXP = 0;
    public int currentExp;
    public Slider healthSlider;
    public Slider ExpSlider;
    public Image damageImage;                                                            
    public float flashSpeed = 5f;                             
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    PlayerCTRL playerMovement;
    bool isDead;
    bool damaged;


    void Awake ()
    {
        playerMovement = GetComponent <PlayerCTRL> ();
        currentHealth = startingHealth;
        currentExp = startingEXP;
    }

    void Update()
    {
 
        // If the player has just been damaged...
        if (damaged)
        {
            // set colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        else
        {
            // transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    public void TakeDamage (int amount)
    {
        damaged = true; // Set the damaged flag so the screen will flash.
        currentHealth -= amount; // Reduce the current health by the damage amount.
        healthSlider.value = currentHealth; // Set the health bar's value to the current health.
        
        if(currentHealth <= 0 && !isDead) // If the player has lost all it's health and the death flag hasn't been set yet
        {
            Death (); // Die
        }
    }

    void Death ()
    {
        isDead = true; // Set the death flag so this function won't be called again.
        Time.timeScale = 0f; // Turn off any remaining shooting effects.
        playerMovement.enabled = false; // Turn off the movement and shooting scripts.
        Destroy(gameObject, 1f);
    }

    public void ItemUpHP()
    {
        currentHealth += 15; // set value of item
        healthSlider.value = currentHealth; // Set the health bar's value to the current health.
    }

    public void ExpUp()
    {
        currentExp += startingEXP; // Increase the current EXP from startingEXP amount.
        ExpSlider.value += expValue;  // Set the exp bar's value to the exp value.
    }

    public void OnTriggerEnter(Collider other)
    {
        {
            if (other.gameObject.CompareTag("item"))
            {
                Destroy(other.gameObject); //destroy item.
                ItemUpHP(); // increase hp.
            }

            if (other.gameObject.CompareTag("Exp"))
            {
                Destroy(other.gameObject); //destroy exp gameobject.
                ExpUp(); // increase exp.
            }

        }
    }
}
