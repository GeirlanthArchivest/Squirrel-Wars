using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float life = 2;
    private string tagToIgnore = "Wall";
    public int hazardDamage = 1;

    void Awake()
    {   //destroy the projectile after reaching value of life
        Destroy(gameObject, life);
    }

    private void Start()
    {
        // Get all colliders in the scene
        Collider2D[] allColliders = FindObjectsOfType<Collider2D>();

        // Loop through each collider
        foreach (Collider2D collider in allColliders)
        {
            // Check if the collider's tag matches the tag to ignore
            if (collider.tag == tagToIgnore)
            {
                // Ignore collision between this object's collider and the collider with the specified tag
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider, true);
            }
        }
    }


    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Boss"))
        {
            //Code to handle collision 
            Collider2D collider = collision.collider;
            BossHealth player = collider.GetComponent<BossHealth>();
            if (player != null)
            {
                //Lose health equal to hazard damage then destroys projectile
                player.ChangeHealth(-hazardDamage);
                Destroy(gameObject);
            }
        }
        // this checks what object type the projectile has collided with
        else if(collision.gameObject.CompareTag("EnemyWall") || collision.gameObject.CompareTag("Enemy"))
        {
            // destroys the object the projectile collided with
            Destroy(collision.gameObject);
            
            //destroys theprojectile
            Destroy(gameObject);


        }
        //else statement in case projectile collides with something it isnt checking for
        else
        {
            //destroys projectile
            Destroy(gameObject);
        }

        
        

        
    }
}
