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
        //Set player's turn to true
        playerTurn = true;
    }

    public void onScreenButtonTouched()
    {
        //Record the time of the button touch
        lastButtonTouchTime = Time.time;
    }

    private void Update()
    {
        //Check if the mouse is over a UI object and return if true
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //Check for mouse button down, player's turn, and cooldown elapsed
        if (Input.GetMouseButtonDown(0) && playerTurn == true && Time.time >= lastButtonTouchTime + touchCooldown)
        {
            //Set processing input to true
            processingInput = true;
            //Convert the screen position of the mouse to world position
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        //Check for mouse button held, player's turn, cooldown elapsed, and processing input
        if (Input.GetMouseButton(0) && playerTurn == true && Time.time >= lastButtonTouchTime + touchCooldown && processingInput == true)
        {
            //Convert the screen position of the mouse to world position
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Calculate velocity based on the difference between start and current mouse positions
            velocity = (startMousePos - currentMousePos) * launchForce;

            //Draw the trajectory using line renderer
            DrawTrajectory();
        }

        //Check for mouse button release, player's turn, cooldown elapsed, and processing input
        if (Input.GetMouseButtonUp(0) && playerTurn == true && Time.time >= lastButtonTouchTime + touchCooldown && processingInput == true)
        {
            //Fire the projectile
            FireProjectile();
            //Set processing input to false
            processingInput = false;
        }
    }

    //Calculate and draw the projectile trajectory using line renderer
    void DrawTrajectory()
    {
        Vector3[] positions = new Vector3[trajectoryStepCount];
        for (int i = 0; i < trajectoryStepCount; i++)
        {
            //Calculate the position at each step of the trajectory
            float t = i * trajectoryTimeStep;
            Vector3 pos = (Vector2)spawnPoint.position + velocity * t + 0.5f * Physics2D.gravity * t * t;

            positions[i] = pos;
        }

        //Set the positions for line renderer
        lineRenderer.positionCount = trajectoryStepCount;
        lineRenderer.SetPositions(positions);
    }

    //Fire the projectile and change turn after a delay
    void FireProjectile()
    {
        //Instantiate the projectile
        Transform pr = Instantiate(ProjectilePrefab, spawnPoint.position, Quaternion.identity);

        //Set the velocity of the projectile
        pr.GetComponent<Rigidbody2D>().velocity = velocity;

        //Set player's turn to false and start coroutine to change turn after a delay
        playerTurn = false;
        StartCoroutine(ChangeTurnAfterDelay());
    }

    //Coroutine to change turn after a delay
    private IEnumerator ChangeTurnAfterDelay()
    {
        //Wait for a specified delay
        yield return new WaitForSeconds(1.5f);

        //Set enemy turns to true for all enemies
        foreach (EnemyAi enemy in enemies)
        {
            enemy.enemyTurn = true;
        }
    }

    //Setter function to set the player's turn
    public void SetPlayerTurn(bool newValue)
    {
        playerTurn = newValue;
    }
}
