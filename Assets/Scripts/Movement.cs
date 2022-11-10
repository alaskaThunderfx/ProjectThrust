using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Preferred variable order:
    // PARAMETERS - for tuning, typically set in the editor
    // CACHE - e.g. references for readability or speed
    // STATE - instance (member) variables

    [SerializeField]
    float mainThrust = 100f;

    [SerializeField]
    float rotationThrust = 100f;

    [SerializeField]
    AudioClip mainEngine;

    [SerializeField]
    ParticleSystem mainBoosterParticles;

    [SerializeField]
    ParticleSystem leftBoosterParticles;

    [SerializeField]
    ParticleSystem rightBoosterParticles;

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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!asrc.isPlaying)
        {
            asrc.PlayOneShot(mainEngine);
        }
        if (!mainBoosterParticles.isPlaying)
        {
            mainBoosterParticles.Play();
        }
    }

    void StopThrusting()
    {
        asrc.Stop();
        mainBoosterParticles.Stop();
    }

    void RotateLeft()
    {
        ApplyRotation(rotationThrust);
        if (!rightBoosterParticles.isPlaying)
        {
            rightBoosterParticles.Play();
        }
    }

    void RotateRight()
    {
        ApplyRotation(-rotationThrust);
        if (!leftBoosterParticles.isPlaying)
        {
            leftBoosterParticles.Play();
        }
    }

    void StopRotating()
    {
        rightBoosterParticles.Stop();
        leftBoosterParticles.Stop();
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
