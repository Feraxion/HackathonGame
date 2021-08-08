using System.Collections;
using System.Collections.Generic;
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
    void Start()
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
            sliderFill.color = Color.Lerp(sliderFill.color,Color.white,1 * Time.deltaTime);
            loser = true;
            decent = false;
            playerMovScript.changeMeshToLoser();
            
        }
        if (slider.value > 19.90f && slider.value < 39.90 && !decent)
        {
            sliderText.text = "Decent";
            sliderFill.color = Color.Lerp(sliderFill.color,Color.blue,1 * Time.deltaTime);
            decent = true;
            loser = false;
            sugarDaddy = false;
            playerMovScript.changeMeshToDecent();
        }
        if (slider.value > 39.90 && !sugarDaddy)
        {
            sliderText.text = "SUGAR DADDY";
            sliderFill.color = Color.Lerp(sliderFill.color,Color.magenta,1 * Time.deltaTime);
            decent = false;
            sugarDaddy = true;
            playerMovScript.changeMeshToSugarDaddy();
        }
    }
}
