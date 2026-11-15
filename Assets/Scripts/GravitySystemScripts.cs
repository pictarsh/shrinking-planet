using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySystemScripts : MonoBehaviour
{
    public bool surfaceGravity;
    
    private Rigidbody _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        if (surfaceGravity)
        {
            GravityAtractiveScripts._instance.PlaceCarOnPlanet(_rb);
        }
        else
        {
            GravityAtractiveScripts._instance.MeteorAttract(_rb);
        }
    }
}
