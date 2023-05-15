using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Launcher : MonoBehaviour
{
    [SerializeField] Transform ProjectilePrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] LineRenderer lineRenderer;

    [SerializeField] float launchForce = 1.5f;
    [SerializeField] float trajectoryTimeStep = 0.05f;
    [SerializeField] int trajectoryStepCount = 15;
    public bool playerTurn;

    Vector2 velocity, startMousePos, currentMousePos;

    private void Start()
    {
        playerTurn = true;
    }

    private void Update()
    {
        
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && playerTurn == true)
        {
            
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0) && playerTurn == true)
        {
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            velocity = (startMousePos = currentMousePos) * launchForce;

            DrawTrajectory();
        }

        if (Input.GetMouseButtonUp(0) && playerTurn == true)
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
        StartCoroutine(ChangeValueAfterDelay());
    }
    
    private IEnumerator ChangeValueAfterDelay()
    {
        yield return new WaitForSeconds(5f);

        playerTurn = false;

    }
    public void SetVariable(bool newValue)
    {
        playerTurn = newValue;
    }
}
