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
    public GameObject cameraFollower,loser,decent,sugarDaddy, rotateModel, finishPos,finishGirl,finishGirl2,girlPos1,girlPos2,finishGirl3,finishGirl4;
    public PlayerSlider slider;
    public bool isFinish;
    public GameManager gameMng;
    public ParticleSystem playerTurnParticle;
    
    public GameObject playerModel;
    
    //Touch settings
    [Header("Touch Settings")]
    [SerializeField] bool isTouching;
    float touchPosX,rotDegree;
    Vector3 direction;

    public int sideway;
    
    //Animation
    //public Animator animator;
    
    //Not sure about this// Getting playerstate from gamemanager
    public GameManager.PlayerState playerState;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        sideway = 2;

    }

    private void Start()
    {
        allWalk();
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
        if (isFinish)
        {
            m_Rigidbody.velocity = Vector3.zero;
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
        
        //Start game if in Playing State
        if (playerState == GameManager.PlayerState.Playing && !isFinish)
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
                rotDegree = Input.GetAxis("Mouse X") * 33;
                rotDegree= Mathf.Clamp(rotDegree,-33,33);
                //playerModel.transform.localRotation = Quaternion.Euler(playerModel.transform.rotation.x,rotDegree,playerModel.transform.rotation.z);
                playerModel.transform.DOLocalRotate(new Vector3(playerModel.transform.localRotation.x, rotDegree, playerModel.transform.localRotation.z),0f);


            }
            else
            {
                playerModel.transform.DOLocalRotate(Vector3.zero,0f);

                //playerModel.transform.localRotation = Quaternion.Euler(Vector3.Lerp(playerModel.transform.rotation.eulerAngles,Vector3.zero, 0.2f)); 
                touchPosX = 0;
            }

            
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

        if (playerState == GameManager.PlayerState.Finish)
        {
            m_Rigidbody.velocity = Vector3.zero;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MatureWoman"))
        {
            StartCoroutine(SliderFill(-15));

            other.GetComponent<Animator>().SetInteger("MatureKiss",1);    
            Destroy(other.gameObject,2f);
            //other.GetComponent<MeshRenderer>().enabled = false;
            other.GetComponent<ObjectParticlePlayer>().PlayParticles();
        }
        
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
            gameMng.IncrementDiamond();
            
            //slider.slider.value
            other.GetComponent<MeshRenderer>().enabled = false;
            other.GetComponent<ObjectParticlePlayer>().PlayParticles();
        }
        
        if (other.gameObject.CompareTag("CollectibleNegative"))
        {

            StartCoroutine(SliderFill(-2));
            //slider.slider.value
            other.GetComponent<MeshRenderer>().enabled = false;
            other.GetComponent<ObjectParticlePlayer>().PlayParticles();
            
        }
        
        if (other.gameObject.CompareTag("PositiveDoor"))
        {

            StartCoroutine(SliderFill(20));
            //slider.slider.value
            other.GetComponent<MeshRenderer>().enabled = false;
            other.GetComponent<ObjectParticlePlayer>().PlayParticles();
            
        }
        
        if (other.gameObject.CompareTag("NegativeDoor"))
        {

            StartCoroutine(SliderFill(-15));
            //slider.slider.value
            other.GetComponent<MeshRenderer>().enabled = false;
            other.GetComponent<ObjectParticlePlayer>().PlayParticles();
            
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            other.GetComponent<ObjectParticlePlayer>().PlayParticles();

            playerState = GameManager.PlayerState.Finish;
            gameObject.transform.DOMove(finishPos.transform.position,3);
            m_Rigidbody.velocity = Vector3.zero;
            StartCoroutine(Wait2());
            

            StartCoroutine(Wait());
        }
        
        
    }
    
    IEnumerator Wait2()
    {
        finishGirl3.GetComponent<Animator>().SetInteger("Movement",2);
        finishGirl4.GetComponent<Animator>().SetInteger("Movement",2);
        
        yield return new WaitForSeconds(2f);
        finishGirl.SetActive(true);
        finishGirl2.SetActive(true);
        finishGirl2.GetComponent<Animator>().SetInteger("Movement",1);
        finishGirl.GetComponent<Animator>().SetInteger("Movement",1);
        
        finishGirl.transform.DOMove(girlPos1.transform.position, 1);
        finishGirl2.transform.DOMove(girlPos2.transform.position, 1);

        yield return new WaitForSeconds(1f);
        finishGirl.transform.DORotate(new Vector3(0, 180, 0), 1);
        
        finishGirl2.transform.DORotate(new Vector3(0, 180, 0), 1);
        finishGirl2.GetComponent<Animator>().SetInteger("Movement",2);
        finishGirl.GetComponent<Animator>().SetInteger("Movement",2);

    }

    IEnumerator Wait()
    {
        
            yield return new WaitForSeconds(3f);
            allDance();
            
            isFinish = true;

    }
    
    IEnumerator Particle()
    {
        playerTurnParticle.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);
        playerTurnParticle.gameObject.SetActive(false);


    }
    
    IEnumerator SliderFill(int fillAmount)
    {
        float perSecond = fillAmount * 0.04f;

        for (int j = 0; j < 25; j++)
        {
            slider.slider.value += perSecond;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void allWalk()
    {
        StartCoroutine(Particle());
        loser.GetComponent<Animator>().SetInteger("Movement",1);
        decent.GetComponent<Animator>().SetInteger("Movement",1);
        sugarDaddy.GetComponent<Animator>().SetInteger("Movement",1);
    }
    
    public void allDance()
    {
        sugarDaddy.GetComponent<Animator>().SetInteger("Movement",2);
        playerModel.transform.DORotate(new Vector3(0, 180, 0), 1);
    }

    public void changeMeshToLoser()
    {
        playerModel = loser;
        loser.gameObject.SetActive(true);
        decent.gameObject.SetActive(false);
        allWalk();
        rotateModel.transform.DOLocalRotate(new Vector3(0, 360, 0), 0.75f,RotateMode.LocalAxisAdd);
    }
    
    public void changeMeshToDecent()
    {
        playerModel = decent;
        decent.gameObject.SetActive(true);
        loser.gameObject.SetActive(false);
        sugarDaddy.gameObject.SetActive(false);
        allWalk();
        rotateModel.transform.DOLocalRotate(new Vector3(0, 360, 0), 0.75f,RotateMode.LocalAxisAdd);

    }
    
    public void changeMeshToSugarDaddy()
    {
        playerModel = sugarDaddy;
        sugarDaddy.gameObject.SetActive(true);
        decent.gameObject.SetActive(false);
        allWalk();
        rotateModel.transform.DOLocalRotate(new Vector3(0, 360, 0), 0.75f,RotateMode.LocalAxisAdd);

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
