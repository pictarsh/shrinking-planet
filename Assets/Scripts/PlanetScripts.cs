using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScripts : MonoBehaviour
{
    public float shrinkSpeed = 1f;
    
    void Update()
    {
        transform.localScale *= 1 - shrinkSpeed * Time.deltaTime;
    }
}
