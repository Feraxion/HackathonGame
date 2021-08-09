using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObstacleRotator : MonoBehaviour
{
    private Transform GO;

    //public bool xRotate, zRotate,yRotate;
    
    [Header("Degree per second")]
    public int xSpeed, ySpeed, zSpeed;

    private Vector3 degree;
    
    [SerializeField]
    //private float RotateSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        degree = new Vector3(xSpeed, ySpeed, zSpeed);
        StartCoroutine(rotateObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //GO = gameObject.transform;
        //GO.transform.rotation.x  += 5f;
        /*Debug.Log(Time.timeScale);
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

        }*/
    }

    IEnumerator rotateObject()
    {
        gameObject.transform.DORotate(degree,21,RotateMode.WorldAxisAdd);
        yield return new WaitForSeconds(20f);
        StartCoroutine(rotateObject());
    }
}
