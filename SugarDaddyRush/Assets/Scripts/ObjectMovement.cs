using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectMovement : MonoBehaviour
{
    [Header("Y Axis Movement")] 
    public bool yMovement;
    
    public float yMin ;
    public float yMax ;
    public float animSpeed;

    public bool moveDown;
    public bool moveUp;

    [Header("X Axis Movement")]
    public bool xMovement;
    
    public float xMin;
    public float xMax;
    public float xAnimSpeed;
    
    public bool moveRight;
    public bool moveLeft;
    
    [Header("Z Axis Movement")]
    public bool zMovement;
        
    public float zMin;
    public float zMax;
    public float zAnimSpeed;
        
    public bool moveForward;
    public bool moveBackward;
    


    private Vector3 movement;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = gameObject.transform.position;

        if (yMovement)
        {
            if(movement.y >= yMax){
                moveDown = true;
                moveUp= false;
            }

            if(movement.y <= yMin){
                moveUp = true;
                moveDown=false;
            }

            if (moveUp)
            {
                movement.y += animSpeed * Time.deltaTime;
            }
            else
            {
                movement.y -= animSpeed * Time.deltaTime;
            }
        }

        if (xMovement)
        {
            if(movement.x >= xMax){
                moveRight = false;
                moveLeft = true;
            }

            if(movement.x <= xMin){
                moveRight = true;
                moveLeft = false;
            }

            if (moveRight)
            {
                movement.x += xAnimSpeed * Time.deltaTime;
            }
            else
            {
                movement.x -= xAnimSpeed * Time.deltaTime;
            }
        }
        
        if (zMovement)
        {
            if(movement.z >= zMax){
                moveForward = false;
                moveBackward = true;
            }

            if(movement.z <= zMin){
                moveForward = true;
                moveBackward = false;
            }

            if (moveForward)
            {
                movement.z += zAnimSpeed * Time.deltaTime;
            }
            else
            {
                movement.z -= zAnimSpeed * Time.deltaTime;
            }
        }
        
        


        gameObject.transform.position = movement;
    }
}
