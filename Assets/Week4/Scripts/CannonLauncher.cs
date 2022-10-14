using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLauncher : MonoBehaviour
{
    //Publicly modifiable variables
    public float launchVelocity = 10f;
    public float launchAngle = 30f;
    public float Gravity = -9.8f;

    //Vector variables
    public Vector3 v3IntitalVelocity;
    public Vector3 v3CurrentVelocity;
    private Vector3 v3Acceleration;

    //Variables for time and displacement
    private float airTime = 0f;
    private float xDisplacement = 0f;

    //Variables that relate to the drawing of the path of the projectile
    private List<Vector3> pathPoints;
    private int simulationSteps = 30; //Number of points on the projectile's path
    
    private bool simulate = false;

    void Start()
    {
        //Initualise path vector for drawing 
        pathPoints = new List<Vector3>();
        CalculateProjectile();
        CalculatePath();
    }
    void Update()
    {
        if(simulate == false){
            pathPoints = new List<Vector3>();
            CalculateProjectile();
            CalculatePath();
        }
        DrawPath();
        if (Input.GetKeyDown(KeyCode.Space) && simulate == false)
        {
            simulate = true;
            v3CurrentVelocity = v3IntitalVelocity;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            simulate = false;
            transform.position = Vector3.zero; //Shorthand for (0,0,0)
        }

    }
    private void FixedUpdate()
    { //Fixed update is used so that every user has the same locked frame rate
        if (simulate)
        {
            Vector3 currentPos = transform.position;
            //Work out current velocity
            v3CurrentVelocity += v3Acceleration * Time.fixedDeltaTime;
            //Work out displacement
            Vector3 displacement = v3CurrentVelocity * Time.fixedDeltaTime;
            currentPos += displacement;
            transform.position = currentPos;
        }
    }
    private void CalculateProjectile(){
        //Work out velocity as vector quantity
        v3IntitalVelocity.x = launchVelocity * Mathf.Cos(launchAngle * Mathf.Deg2Rad);
        v3IntitalVelocity.y = launchVelocity * Mathf.Sin(launchAngle * Mathf.Deg2Rad);

        //Gravity as a vector
        v3Acceleration = new Vector3(0f, Gravity, 0f);

        //Calculate total time in air
        float finalYVel = 0f;
        airTime = 2f * (finalYVel - v3IntitalVelocity.y) / v3Acceleration.y;

        //Calculate total distance travelled in x
        xDisplacement = airTime * v3IntitalVelocity.x;
    }
    private void CalculatePath(){
        Vector3 launchPos = transform.position;
        pathPoints.Add(launchPos);

        for (int i = 0; i < simulationSteps; i++){
            float simTime = (i / (float)simulationSteps) * airTime ;
            //SUVAT formula for the displacement: s = ut + 1/2at^2
            Vector3 displacement = v3IntitalVelocity * simTime + v3Acceleration * simTime * simTime * 0.5f;
            Vector3 drawPoint = launchPos + displacement;
            pathPoints.Add (drawPoint);
        }
    }
    void DrawPath(){
        for (int i = 0; i < pathPoints.Count -1; i++){
            Debug.DrawLine(pathPoints[i], pathPoints[i + 1], Color.green);
        }
    }
}
