using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    private Vector3 startPos;
    [SerializeField]
    private float Speed = 2f;
    [SerializeField]
    private float rotateSpeed = 180f;
    [SerializeField]
    private float displacement = 5f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))    //Code only runs when space is presssed
        {
            //transform.position = startPos + new Vector3( displacement / timeElapsed * Time.time, displacement / timeElapsed * Time.time, displacement / timeElapsed * Time.time);

            float xMove = Speed * Mathf.Sin(Speed * Time.time); //Moves x along the sin curve
            float yMove = Speed * Mathf.Cos(Speed * Time.time); //Moves y along the cos curve
            transform.position = startPos + new Vector3(xMove, yMove, 0);  //Makes cube move in a circle

            float xRotate = rotateSpeed;
            float yRotate = rotateSpeed;
            transform.Rotate(xRotate, yRotate, 0);  //Changing the rotation of the cube

            transform.localScale = new Vector3((xMove + 1) / 2, (yMove + 1) / 2, 5);    //Scaling the shape by changing size
        }
    }
}
