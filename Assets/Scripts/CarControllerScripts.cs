using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarControllerScripts : MonoBehaviour
{
    public float moveSpeed = 10f, turningSpeed = 10f;
    public AudioSource deathAudio;
    public GameObject gameOverCanvas;
    public InputAction movement;
    
    private Rigidbody _rb;
    private AudioSource _audioSource;

    void OnEnable()
    {
        movement.Enable();
    }

    void OnDisable()
    {
        movement.Disable();
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }
    
    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + transform.forward * moveSpeed * Time.deltaTime);
        Vector3 direction = Vector3.up * movement.ReadValue<float>() * turningSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(direction);
        _rb.MoveRotation(_rb.rotation * rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bom"))
        {
            print("Game Over!!!");
            _audioSource.Stop();
            deathAudio.Play();
            Time.timeScale = 0;
            gameOverCanvas.SetActive(true);
        }
    }
}
