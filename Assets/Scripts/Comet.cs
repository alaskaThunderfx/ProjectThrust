using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : MonoBehaviour
{
    [SerializeField]
    float xAxis = 0;

    Vector3 startingPosition;

    private void Start() {
        startingPosition = transform.position;
    }

    void Update()
    {
        Fly();
    }

    private void Fly()
    {
        transform.position += new Vector3(xAxis, 0, 0);
        if (transform.position.x >= 400)
        {
            transform.position = startingPosition;
        }
    }
}
