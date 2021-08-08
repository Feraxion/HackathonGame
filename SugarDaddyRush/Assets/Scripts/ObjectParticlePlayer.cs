using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectParticlePlayer : MonoBehaviour
{

    public GameObject[]  particles;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayParticles()
    {
        foreach (var particle in particles)
        {
            particle.SetActive(true);
        }
    }
}
