using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : MonoBehaviour
{
    [SerializeField]
    Vector3 moveVector = new Vector3(0, 0, 0);
    [SerializeField]
    float maxXAxis = 400;
    [SerializeField]
    float minXAxis = -400;
    [SerializeField]
    float maxYAxis = 400;
    [SerializeField]
    float minYAxis = -750;


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
        float currentX = transform.position.x;
        float currentY = transform.position.y;

        transform.position += (moveVector * Time.deltaTime);

        if (currentX >= maxXAxis || currentX <= minXAxis || currentY >= maxYAxis || currentY <= minYAxis)
        {
            transform.position = startingPosition;
        }
    }
}
