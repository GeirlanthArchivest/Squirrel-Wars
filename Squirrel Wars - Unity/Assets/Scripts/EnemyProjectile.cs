using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private float life = 2;
    private string tagToIgnore = "EnemyWall";

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

        // this checks what object type the projectile has collided with
        if (collision.gameObject.CompareTag("Wall") ||
           collision.gameObject.CompareTag("Character"))
        {
            // destroys the object the projectile collided with
            Destroy(collision.gameObject);

            //destroys theprojectile
            Destroy(gameObject);


        }
        //Check if the projectile is colliding with an enemy and returns if true
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            return;
        }
        //else statement in case projectile collides with something it isnt checking for
        else
        {
            //destroys projectile
            Destroy(gameObject);
        }





    }
}
