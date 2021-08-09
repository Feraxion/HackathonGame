using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlider : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI sliderText;
    public Image sliderFill;
    public bool loser,decent,sugarDaddy;

    public PlayerMovement playerMovScript;
    // Start is called before the first frame update
    void Awake()
    {
        loser = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckForTextChange()
    {
        if (slider.value < 19.90 &&  !loser)
        {
            sliderText.text = "Loser";
            //sliderFill.DOColor(new Color(244,93,76), 1);
            sliderFill.DOColor(Color.red, 1);

            loser = true;
            decent = false;
            playerMovScript.changeMeshToLoser();
            
        }
        if (slider.value > 19.90f && slider.value < 39.90 && !decent)
        {
            sliderText.text = "Decent";
            //sliderFill.color = Color.Lerp(sliderFill.color,Color.blue,1 * Time.deltaTime);
            sliderFill.DOColor(Color.yellow, 1);
            //sliderFill.color = Color.Lerp(sliderFill.color,new Color(250,202,102), 1);

            
            decent = true;
            loser = false;
            sugarDaddy = false;
            playerMovScript.changeMeshToDecent();
        }
        if (slider.value > 39.90 && !sugarDaddy)
        {
            sliderText.text = "SUGAR DADDY";
            //sliderFill.color = Color.Lerp(sliderFill.color,Color.magenta,1 * Time.deltaTime);
            //sliderFill.DOColor(new Color(161,219,178), 1);
            sliderFill.DOColor(Color.magenta, 1);

            decent = false;
            sugarDaddy = true;
            playerMovScript.changeMeshToSugarDaddy();
        }
    }
}
