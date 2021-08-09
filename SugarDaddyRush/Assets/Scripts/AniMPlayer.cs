using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniMPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetInteger("Movement",4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
