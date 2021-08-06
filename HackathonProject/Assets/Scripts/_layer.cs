using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject startPos;
    public GameObject cube;
    public bool isBoolRunning;
    
    // Start is called before the first frame update
    void Start()
    {
        isBoolRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FormShape"))
        {
            if (!isBoolRunning)
            {
                StartCoroutine(FlyCube(other.gameObject));
                
                StartCoroutine(ResetBool());
            }

        }
    }

    IEnumerator FlyCube(GameObject other)
    {

        
        
        int width = other.GetComponent<FormShapeInfo>().width;
        int height = other.GetComponent<FormShapeInfo>().height;
        int depth = other.GetComponent<FormShapeInfo>().depth;
        bool merdiven = other.GetComponent<FormShapeInfo>().merdiven;

        int p = 0;

        for (int i = 0; i < height; i++)
        {
            
            for (int j = p; j < depth; j++)
            {
                for (int d = 0; d < width; d++)
                {
                    if ( i ==  j&& merdiven)
                    {
                        //Merdiven bloklari gelicek
                        GameObject shaper = Instantiate(cube, startPos.transform.position, Quaternion.Euler(45,0,0));
                        shaper.transform.DOMove(new Vector3(0 + (d * 0.6f), -0.85f + (i * 0.6f), 43.42f + (j * 0.6f)), 1);
                        shaper.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f),1);
                        yield return new WaitForSeconds(0.03f);
                        shaper.GetComponent<BoxCollider>().enabled = true;
                        
                    }
                    else
                    {
                        GameObject shaper = Instantiate(cube, startPos.transform.position, Quaternion.identity);
                        shaper.transform.DOMove(new Vector3(0 + (d * 0.5f), -0.85f + (i * 0.5f), 43.42f + (j * 0.6f)), 1);
                        shaper.transform.DOScale(new Vector3(0.6f, 0.55f, 0.6f),1);
                        yield return new WaitForSeconds(0.03f);
                        shaper.GetComponent<BoxCollider>().enabled = true;
                    }
                    
                    

                    
                }

               

            }

            if (merdiven)
            {
                p++;

            }

            
        }
    }
    
    IEnumerator ResetBool()
    {
        isBoolRunning = true;

        yield return new WaitForSeconds(5f);
        isBoolRunning = false;
    }
}
