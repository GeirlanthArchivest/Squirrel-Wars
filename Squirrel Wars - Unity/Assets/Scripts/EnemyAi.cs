using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    //The target position to shoot at
    public Transform target;                     
    //Prefab of the projectile
    public GameObject projectilePrefab;          
    //The force applied to shoot the projectile
    private float shootingForce;             
    public Launcher Launcher;

    public bool enemyTurn = false;

    private void Update()
    {
        if (enemyTurn == true)
        {
            StartCoroutine(Shoot());
        }

    }

    private IEnumerator Shoot()
    {
        enemyTurn = false;
        shootingForce = Random.Range(10f, 20f);

        Vector2 direction = target.position - transform.position;

        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

        // Apply a force to shoot the projectile towards the target
        projectileRb.AddForce(direction.normalized * shootingForce, ForceMode2D.Impulse);


        yield return new WaitForSeconds(3f);


        Launcher.SetPlayerTurn(true);

    }

}
