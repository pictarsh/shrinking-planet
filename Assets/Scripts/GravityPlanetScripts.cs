using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlanetScripts : MonoBehaviour
{
    public static GravityPlanetScripts _instance;
    // public float garvityScale = 1f;
    public float shrinkSpeed = 1f;
    public float gravitySpeed = 1f;

    private SphereCollider _col;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    void Start()
    {
        _col = GetComponent<SphereCollider>();
    }

    void Update()
    {
        if (transform.localScale.x > 0.5f)
        {
            transform.localScale *= 1 - shrinkSpeed * Time.deltaTime;
        }
        
    }

    private void Rotate(Rigidbody rb)
    {
        // Vector3 gravityUp = (rb.position - transform.position).normalized;
        Vector3 target = (rb.position - transform.position).normalized;
        
        // rb.MoveRotation(Quaternion.FromToRotation(rb.transform.up, gravityUp) * rb.rotation);
        rb.MoveRotation(Quaternion.FromToRotation(rb.transform.up, target) * rb.rotation);
    }

    public void MobilJatoh(Rigidbody  rb)
    {
        rb.MovePosition((rb.position - transform.position).normalized * (transform.localScale.x * _col.radius));
        Rotate(rb);
    }

    public void MeteorJatoh(Rigidbody rb)
    {
        rb.AddForce((rb.position - transform.position).normalized * (-gravitySpeed));
        Rotate(rb);
    }
}
