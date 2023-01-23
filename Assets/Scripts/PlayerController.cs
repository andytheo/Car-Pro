using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4;
    public Rigidbody rb;
    float horizontalDirection;
    float horizontalDirectionSpeed = 2;

    private void FixedUpdate()
    {
        Vector3 forwardMovement = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMovement = transform.right * horizontalDirection * speed 
            * Time.fixedDeltaTime * horizontalDirectionSpeed;

        rb.MovePosition(rb.position + forwardMovement + horizontalMovement);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalDirection= Input.GetAxis("Horizontal");
    }
}
