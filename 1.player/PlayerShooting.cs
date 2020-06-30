using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20; // The damage inflicted by each bullet.
    public float timeBetweenBullets = 0.15f; // The time between each shot.
    public float range = 100f; // The distance the gun can fire.


    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    Light gunLight;
    float effectsDisplayTime = 0.2f;


    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable"); // Create a layer mask for the Shootable layer.
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunLight = GetComponent<Light> ();
    }


    void Update ()
    {
        timer += Time.deltaTime; // Add the time since Update was last called to the timer.

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0) // If the Fire1 button is being press and it's time to fire.
        {
            Shoot (); // shoot a gun
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime) // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for.
        {
            DisableEffects (); // disable the effects.
        }
    }


    public void DisableEffects ()
    {
        // Disable the line renderer and the light.
	gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot ()
    {
        timer = 0f; // Reset the timer.

        gunLight.enabled = true; // Enable the light.

        // Stop the particles from playing if they were, then start the particles.
	gunParticles.Stop ();
        gunParticles.Play ();

        // Enable the line renderer and set it's first position to be the end of the gun.
	gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);

        // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
	shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        // Perform the raycast against gameobjects on the shootable layer and if it hits something.
	if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> (); // find an EnemyHealth script on the gameobject hit.
            
	    if(enemyHealth != null) // If the EnemyHealth component exist...
            {
                enemyHealth.TakeDamage (damagePerShot, shootHit.point); // the enemy should take damage.
            }
            gunLine.SetPosition (1, shootHit.point); // Set the second position of the line renderer to the point the raycast hit.
        }
        else // If the raycast didn't hit anything on the shootable layer.
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range); // set the second position of the line renderer to the fullest extent of the gun's range.
        }
    }
}
