using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float life = 2;

    void Awake()
    {   //destroy the projectile after reaching value of life
        Destroy(gameObject, life);
    }


    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        // this checks what object type the projectile has collided with
        if(collision.gameObject.CompareTag("Wall") ||
           collision.gameObject.CompareTag("Enemy") ||
           collision.gameObject.CompareTag("Character"))
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
