using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlider : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI sliderText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckForTextChange()
    {
        if (slider.value < 14.90)
        {
            sliderText.text = "Loser";
        }
        if (slider.value > 14.90f && slider.value < 29.90)
        {
            sliderText.text = "Decent";
        }

        if (slider.value > 29.90 && slider.value < 44.90)
        {
            sliderText.text = "Cool";
        }
        
        if (slider.value > 44.90 && slider.value < 59.90)
        {
            sliderText.text = "Playboy";
        }

        if (slider.value > 59.90 )
        {
            sliderText.text = "SUGAR DADDY";
        }
    }
}
