using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public Transform target;                     // The target position to shoot at
    public GameObject projectilePrefab;          // Prefab of the projectile
    public float shootingForce = 10f;             // The force applied to shoot the projectile
    public Launcher Launcher;

    private void Update()
    {
        bool playerTurn = Launcher.playerTurn;

        if (playerTurn == false)
        {
            Launcher.SetVariable(true);
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector2 direction = target.position - transform.position;

        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

        // Apply a force to shoot the projectile towards the target
        projectileRb.AddForce(direction.normalized * shootingForce, ForceMode2D.Impulse);

    }
}
