using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField]
    float speed = 1;

    [SerializeField]
    float startingRotation = 0;

    [SerializeField]
    float rotationDegrees = 45;

    void Update()
    {
        float rY = Mathf.SmoothStep(
            startingRotation,
            rotationDegrees,
            Mathf.PingPong(Time.time * speed, 1)
        );
        transform.rotation = Quaternion.Euler(rY, 0, 0);
    }
}
