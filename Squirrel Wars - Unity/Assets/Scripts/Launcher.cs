using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] Transform ProjectilePrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] LineRenderer lineRenderer;

    [SerializeField] float launchForce = 1.5f;
    [SerializeField] float trajectoryTimeStep = 0.05f;
    [SerializeField] int trajectoryStepCount = 15;

    [SerializeField] float FireBoundaryLow = 75;
    [SerializeField] float FireBoundaryHigh = 100000;



    Vector2 velocity, startMousePos, currentMousePos;

    private void Update()
    {
        //stops shooting being possible in deadzones values in fireboundaries
        if (Input.mousePosition.x < FireBoundaryLow || Input.mousePosition.x > FireBoundaryHigh)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            velocity = (startMousePos = currentMousePos) * launchForce;

            DrawTrajectory();
        }

        if (Input.GetMouseButtonUp(0))
        {
            FireProjectile();
        }
    }

    void DrawTrajectory()
    {
        Vector3[] positions = new Vector3[trajectoryStepCount];
        for(int  i = 0; i < trajectoryStepCount; i++)
        {
            float t = i * trajectoryTimeStep;
            Vector3 pos = (Vector2)spawnPoint.position + velocity * t + 0.5f * Physics2D.gravity * t * t;

            positions[i] = pos;
        }

        lineRenderer.positionCount = trajectoryStepCount;
        lineRenderer.SetPositions(positions);
    }

    void FireProjectile()
    {
        Transform pr = Instantiate(ProjectilePrefab, spawnPoint.position, Quaternion.identity);

        pr.GetComponent<Rigidbody2D>().velocity = velocity;
    }

}
