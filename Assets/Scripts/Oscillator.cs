using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;

    [SerializeField]
    Vector3 movementVector;

    [SerializeField]
    float period = 2f;
    float movementFactor;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if (period <= Mathf.Epsilon)
            return;

        // Continually growing over time
        float cycles = Time.time / period;

        // Constant value of 6.283
        const float tau = Mathf.PI * 2;
        // going from -1 to 1
        float rawSineWave = Mathf.Sin(cycles * tau);

        // Recalculated to go from 0 to 1 (it's center)
        movementFactor = (rawSineWave + 1f) / 2;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
