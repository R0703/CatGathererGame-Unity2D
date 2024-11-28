using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float movSpeed = 2f;
    public float directionChangedInterval = 3f;
    public float boundaryRadius = 5f;

    private Vector2 movement;
    private Vector3 startingPos;
    void Start()
    {
        startingPos = transform.position;
        StartCoroutine(ChangeMovementDirection());
    }

    private void Update()
    {
        transform.Translate(movement * movSpeed * Time.deltaTime);

        //keep annoyance at boundary
        Vector3 distanceFromStart = transform.position - startingPos;

        if (distanceFromStart.magnitude > boundaryRadius)
        {
            Vector3 fromOrigintoObject = transform.position - startingPos;
            fromOrigintoObject *= boundaryRadius / fromOrigintoObject.magnitude;
            transform.position = startingPos + fromOrigintoObject;
        }
    }

    //coroutine
    System.Collections.IEnumerator ChangeMovementDirection()
    {
        while (true)
        {
            float angle = Random.Range(0f, 360f);
            movement = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

            //wait at interval value to change directions
            yield return new WaitForSeconds(directionChangedInterval);
        }
    }
}
