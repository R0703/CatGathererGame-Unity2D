using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public float movSpeed = 5f;
    Rigidbody2D rb2;
    public Camera maincamera;
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        maincamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float moveH = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 move = new Vector2(moveH, moveY);
        rb2.velocity = move * movSpeed;

        if (maincamera != null)
        {
            maincamera.transform.position = new Vector3(transform.position.x, transform.position.y, maincamera.transform.position.z);
        }
        else
        {
            Debug.Log("Camera us not set");
        }

    }
}
