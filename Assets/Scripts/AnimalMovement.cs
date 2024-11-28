using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float xLimit = 5f;
    public float yLimit = 5f;
    Rigidbody2D rb2;
    private Vector2 direction;
    private float timer;
    private float changeDirectionTime = 2f;
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        changeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeDirectionTime)
        {
            changeDirection();
            timer = 0f;
        }

        rb2.velocity = direction * movementSpeed;
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -xLimit, xLimit);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -yLimit, yLimit);
        transform.position = clampedPosition;
    }

    void changeDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        direction = new Vector2(randomX, randomY);
    }
}
