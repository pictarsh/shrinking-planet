using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteroScripts : MonoBehaviour
{
    public ParticleSystem particles;
    public GameObject create;
    private Collider _col;
    private AudioSource _audioSource;
    
    void Start()
    {
        _col = GetComponent<Collider>();
        _audioSource = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision other)
    {
        _audioSource.Play();
        Instantiate(create, other.contacts[0].point, transform.rotation);
        particles.Stop();
        _col.enabled = false;
        Destroy(gameObject, 1f);
    }
}
