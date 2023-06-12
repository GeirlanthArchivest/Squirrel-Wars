using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public Transform target;
    public GameObject projectilePrefab;          
    private float shootingForce;             
    public Launcher Launcher;
    public int minForce;
    public int maxForce;

    public bool enemyTurn = false;

    private void Update()
    {
        if (enemyTurn == true)
        {
            //Start shooting coroutine
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        //Set enemys turn to false temporarily
        enemyTurn = false;
        //Randomize the shooting force
        shootingForce = Random.Range(minForce, maxForce);

        //Calculate the direction towards the target
        Vector2 direction = target.position - transform.position;

        //Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

        //Apply a force to shoot the projectile towards the target
        projectileRb.AddForce(direction.normalized * shootingForce, ForceMode2D.Impulse);

        //Wait for 3 seconds before resuming
        yield return new WaitForSeconds(3f);

        //Set the players turn to true using the reference to the launcher
        Launcher.SetPlayerTurn(true);

    }

}