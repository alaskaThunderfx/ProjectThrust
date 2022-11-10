using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightProbing : MonoBehaviour
{
    [SerializeField]
    float maxRange = 10;

    [SerializeField]
    float minRange = .1f;

    [SerializeField]
    float strobeSpeed = .5f;

    Light lit;

    private void Start() {
        lit = GetComponent<Light>();
    }

    void Update()
    {
        lit.intensity = Mathf.Lerp(minRange, maxRange, Mathf.PingPong(Time.time, strobeSpeed));
    }
}
