using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Preferred variable order:
    // PARAMETERS - for tuning, typically set in the editor
    // CACHE - e.g. references for readability or speed
    // STATE - private instance (member) variables

    [SerializeField]
    float mainThrust = 100f;

    [SerializeField]
    float rotationThrust = 100f;

    [SerializeField]
    AudioClip mainEngine;

    Rigidbody rb;
    AudioSource asrc;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        asrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!asrc.isPlaying)
            {
                asrc.PlayOneShot(mainEngine);
            }
        }
        else
        {
            asrc.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        // Freezing rotation so we can manually rotate
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        // Unfreezing rotation so physics system can take over
        rb.freezeRotation = false;
    }
}
