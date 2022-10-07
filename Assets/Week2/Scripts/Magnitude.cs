using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnitude : MonoBehaviour
{
    [SerializeField]    //Ensures that the variable vec3 can be seen in the inspector
    private Vector3 vec3;

    public float calculateMagnitudeVec3(Vector3 vec)
    {
        return Mathf.Sqrt((vec.x * vec.x) + (vec.y * vec.y) + (vec.z * vec.z)); //Magniutde is the square root of x squared + y squared + z squared
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("The vector is: "+ vec3);  //Debug writes messages to the console window
        Debug.Log("The magnitude is:"+ calculateMagnitudeVec3(vec3));   
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
