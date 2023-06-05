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
    public float touchCooldown;
    private float lastButtonTouchTime;
    private bool processingInput = false;


    [SerializeField] EnemyAi[] enemies;

    Vector2 velocity, startMousePos, currentMousePos;

    private void Start()
    {
        playerTurn = true;
    }

    public void onScreenButtonTouched()
    {
        lastButtonTouchTime = Time.time;
    }

    private void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && playerTurn == true && Time.time >= lastButtonTouchTime + touchCooldown)
        {
            processingInput = true;
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0) && playerTurn == true && Time.time >= lastButtonTouchTime + touchCooldown && processingInput == true)
        {
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            velocity = (startMousePos - currentMousePos) * launchForce;

            DrawTrajectory();
        }

        if (Input.GetMouseButtonUp(0) && playerTurn == true && Time.time >= lastButtonTouchTime + touchCooldown && processingInput == true)
        {
            FireProjectile();
            processingInput = false;
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
        playerTurn = false;
        StartCoroutine(ChangeTurnAfterDelay());
    }
    
    private IEnumerator ChangeTurnAfterDelay()
    {
        yield return new WaitForSeconds(1.5f);

        foreach (EnemyAi enemy in enemies)
        {
            enemy.enemyTurn = true;
        }

    }
    public void SetPlayerTurn(bool newValue)
    {
        playerTurn = newValue;
    }
}
