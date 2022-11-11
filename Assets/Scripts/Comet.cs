using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : MonoBehaviour
{
    [SerializeField]
    Vector3 moveVector = new Vector3(0, 0, 0);

    Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        Fly();
    }

    private void Fly()
    {
        transform.position += moveVector;
        if (transform.position.x >= 400)
        {
            transform.position = startingPosition;
        }
    }
}
