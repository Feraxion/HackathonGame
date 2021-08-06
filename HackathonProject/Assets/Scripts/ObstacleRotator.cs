using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotator : MonoBehaviour
{
    private Transform GO;

    public bool xRotate, zRotate,yRotate;

    
    [SerializeField]
    private float RotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //GO = gameObject.transform;
        //GO.transform.rotation.x  += 5f;
        Debug.Log(Time.timeScale);
        if (xRotate)
        {
            gameObject.transform.Rotate(RotateSpeed * Time.deltaTime,0f,0f);

        }

        if (yRotate)
        {
            gameObject.transform.Rotate(0,RotateSpeed* Time.deltaTime,0);

        }

        if (zRotate)
        {
            gameObject.transform.Rotate(0,0,RotateSpeed* Time.deltaTime);

        }
    }
}
