using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    [Header("Speed Settings")]
    public float movementSpeed;
    public float controlSpeed;
    //public Quaternion rotateObj;
    public GameObject cameraFollower;
    public PlayerSlider slider;

    public GameObject playerModel;
    
    //Touch settings
    [Header("Touch Settings")]
    [SerializeField] bool isTouching;
    float touchPosX,rotDegree;
    Vector3 direction;

    public int sideway;
    
    //Animation
    public Animator animator;
    
    //Not sure about this// Getting playerstate from gamemanager
    public GameManager.PlayerState playerState;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        sideway = 2;

    }

    private void Update()
    {
        //Make sure its in sync
        playerState =  GameManager.inst.playerState ;

        //Start game if in Playing State
        if (playerState == GameManager.PlayerState.Playing)
        {
            GetInput();


        }

       
    }

    private void FixedUpdate()
    {
        //Start game if in Playing State
        if (playerState == GameManager.PlayerState.Playing)
        {
            //RigidBody Eklentisinden sonra burası rigidbody olarak değişecek
            //m_Rigidbody.AddForce(transform.forward * movementSpeed);
            //transform.position += m_Rigidbody.AddForce(transform.forward * movementSpeed);
            //transform.position += Vector3.forward * movementSpeed * Time.fixedDeltaTime;
            m_Rigidbody.velocity = transform.forward * movementSpeed;
           // animator.SetTrigger("GameStart"); // start the animation
            //m_Rigidbody.AddForce(Vector3.forward * movementSpeed * Time.fixedDeltaTime);
        
            if (isTouching)
            {
                touchPosX = Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;
                
                //Debug.Log(Input.GetAxis("Mouse X"));
               // rotateObj = Quaternion.Euler(0,Input.GetAxis("Mouse X")* 100 ,0);
                //rotateObj.y = Mathf.Clamp(rotateObj.y,-30,30);
                //gameObject.transform.rotation = rotateObj;
                //Debug.Log(Input.GetAxis("Mouse X"));
               // float rotateDegree = Input.GetAxis("Mouse X") * 25;
                //playerModel.transform.Rotate(new Vector3(0,rotateDegree,0),Space.World);
                
                

            }
            else
            {
                touchPosX = 0;
            }
            
            //rotDegree = Input.GetAxis("Mouse X") * 25;
            //rotDegree= Mathf.Clamp(rotDegree,-25,25);
            //playerModel.transform.rotation = Quaternion.Euler(playerModel.transform.rotation.x,rotDegree,playerModel.transform.rotation.z);

            switch (sideway)
            {
                case 1:
                    transform.position += new Vector3(0, 0, touchPosX);

                    return;
                case 2:
                    transform.position += new Vector3(touchPosX, 0, 0);

                    return;
                case 3:
                    transform.position += new Vector3(0, 0, -touchPosX);

                    return;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ReturnLeft"))
        {
            m_Rigidbody.velocity = Vector3.zero;
            
            Vector3 rotateLeft = new Vector3(0, -90, 0);
            cameraFollower.transform.DORotate(rotateLeft, 1.4f);
            gameObject.transform.DORotate(rotateLeft, 1.4f);

            sideway = 1;
            
        }
        
        if (other.gameObject.CompareTag("ReturnMiddle"))
        {
            m_Rigidbody.velocity = Vector3.zero;
            
            Vector3 rotateMiddle = new Vector3(0, 0, 0);
            cameraFollower.transform.DORotate(rotateMiddle, 1.4f);
            gameObject.transform.DORotate(rotateMiddle, 1.4f);

            sideway = 2;
            
        }

        if (other.gameObject.CompareTag("ReturnRight"))
        {
            m_Rigidbody.velocity = Vector3.zero;

            Vector3 rotateRight = new Vector3(0, 90, 0);
            cameraFollower.transform.DORotate(rotateRight, 1.4f);
            gameObject.transform.DORotate(rotateRight, 1.4f);

            sideway = 3;
        }

        if (other.gameObject.CompareTag("CollectibleMoney"))
        {

            StartCoroutine(SliderFill(2));
            //slider.slider.value
            Destroy(other.gameObject,0.1f);
        }
        
        if (other.gameObject.CompareTag("CollectibleNegative"))
        {

            StartCoroutine(SliderFill(-2));
            //slider.slider.value
            Destroy(other.gameObject,0.1f);
        }
        
        if (other.gameObject.CompareTag("PositiveDoor"))
        {

            StartCoroutine(SliderFill(20));
            //slider.slider.value
            Destroy(other.gameObject,0.1f);
        }
        
        if (other.gameObject.CompareTag("NegativeDoor"))
        {

            StartCoroutine(SliderFill(-15));
            //slider.slider.value
            Destroy(other.gameObject,0.1f);
        }
        
        
    }


    IEnumerator SliderFill(int fillAmount)
    {
        float perSecond = fillAmount * 0.02f;

        for (int j = 0; j < 50; j++)
        {
            slider.slider.value += perSecond;
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(2f);
    }

    //Testing Inputs
    void GetInput()
    {
        if (Input.GetMouseButton(0))
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }
    //Mobile Inputs
    void GetInputMobile()
    {
        if (Input.touchCount > 0)
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }
}
