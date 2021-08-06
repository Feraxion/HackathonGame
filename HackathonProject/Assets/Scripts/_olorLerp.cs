using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] float lerpTime;
    [SerializeField] Color[] myColor;
    MeshRenderer myRenderer;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        LerpColor();
    }

    public void LerpColor()
    {
        if (Time.timeScale < 1)
        {
            myRenderer.material.color = Color.Lerp(myRenderer.material.color, myColor[0], lerpTime);
        }
        if (Time.timeScale == 1)
        {
            myRenderer.material.color = Color.Lerp(myRenderer.material.color, myColor[1], lerpTime);
        }
    }
}
