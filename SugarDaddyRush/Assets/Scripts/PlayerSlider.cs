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
            sliderFill.color = Color.Lerp(sliderFill.color,Color.white,1 * Time.deltaTime);

        }
        if (slider.value > 14.90f && slider.value < 29.90)
        {
            sliderText.text = "Decent";
            sliderFill.color = Color.Lerp(sliderFill.color,Color.blue,1 * Time.deltaTime);

        }

        if (slider.value > 29.90 && slider.value < 44.90)
        {
            sliderText.text = "Cool";
            sliderFill.color = Color.Lerp(sliderFill.color,Color.green,1 * Time.deltaTime);

        }
        
        if (slider.value > 44.90 && slider.value < 59.90)
        {
            sliderText.text = "Playboy";
            sliderFill.color = Color.Lerp(sliderFill.color,Color.yellow,1 * Time.deltaTime);

        }

        if (slider.value > 59.90 )
        {
            sliderText.text = "SUGAR DADDY";
            sliderFill.color = Color.Lerp(sliderFill.color,Color.magenta,1 * Time.deltaTime);

        }
    }
}
