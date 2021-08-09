using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Tabtale.TTPlugins;

public class GameManager : MonoBehaviour
{
    [Header("Diamond Stats")]
    [SerializeField] public int diamondCount;
    

    [SerializeField] public TextMeshProUGUI diamondText;
    public GameObject StartScreen;
    public GameObject FinishScreen;
    public GameObject GameOverScreen;


    public static GameManager inst;
    
    public enum PlayerState
    {
        Prepare,
        Playing,
        Died,
        Shopping,
        Finish
    }

    public PlayerState playerState;
    
    

    private void Awake()
    {
        TTPCore.Setup();
    
        
        inst = this;
        playerState = PlayerState.Prepare;
            //Application.targetFrameRate = 60;
    }

    private void Start()
    {
    }

    void Update()
    {
        if (playerState == PlayerState.Prepare)
        {
            StartScreen.SetActive(true);
//            diamondText.text = "" + (currentLevelDiamondCount + diamondCount) ;

        }

        if (playerState == PlayerState.Finish)
        {
                

            
               

            FinishScreen.SetActive(true);
            
        }

        if (playerState == PlayerState.Died)
        {
            GameOverScreen.SetActive(true);
        }
    }
    public void IncrementDiamond()
    {
        //Keeps it in temporary variable in case player dies before finishing
        diamondCount += 20;
        diamondText.text = "" + diamondCount ;
    }

    public void BonusAdWatched()
    {

            //Adds the 3x video watched bonus
            
            //Defaults them for next level
                    
            //Updates the text
            diamondText.text = ""  + diamondCount ;
        
            PlayerPrefs.SetInt("diaAmount",diamondCount);

    }
    
    IEnumerator WaitAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(true);
    }

   
    
    
}
