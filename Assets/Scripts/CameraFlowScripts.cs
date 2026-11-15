using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlowScripts : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    
    private void Update()
    {
        transform.position = target.TransformDirection(offset);
        transform.rotation = Quaternion.LookRotation((target.position - transform.position), target.forward);
    }
}
