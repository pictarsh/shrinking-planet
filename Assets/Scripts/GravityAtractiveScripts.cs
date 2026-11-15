using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAtractiveScripts : MonoBehaviour
{
    public static GravityAtractiveScripts _instance;
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

    private void Rotate(Rigidbody rb)
    {
        Vector3 gravityUp = (rb.position - transform.position).normalized;
        rb.MoveRotation(Quaternion.FromToRotation(rb.transform.up, gravityUp) * rb.rotation);
    }

    public void PlaceCarOnPlanet(Rigidbody rb)
    {
        rb.MovePosition((rb.position - transform.position).normalized * (transform.localScale.x * _col.radius));
        Rotate(rb);
    }

    public void MeteorAttract(Rigidbody rb)
    {
        rb.AddForce((rb.position - transform.position).normalized * (-gravitySpeed));
        Rotate(rb);
    }
}
