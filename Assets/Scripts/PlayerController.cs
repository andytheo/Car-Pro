using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;
    float horizontalDirection;
    float horizontalDirectionSpeed = 2;
    private GameManager gameManager;
    public GameObject coinEffect;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void FixedUpdate()
    {
        Vector3 forwardMovement = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMovement = transform.right * horizontalDirection * speed
            * Time.fixedDeltaTime * horizontalDirectionSpeed;

        // Accelerating and decelerrating
        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed += 2f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            speed -= .5f;
        }

        rb.MovePosition(rb.position + forwardMovement + horizontalMovement);

        // Keep car within bounds of the road
        //ClampCarPosition();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalDirection = Input.GetAxis("Horizontal");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            gameManager.IncreaseScore();

            GameObject g = Instantiate(coinEffect, transform.position, Quaternion.identity);
            Destroy(g, 2);
            Destroy(other.gameObject);
        }
    }

    private void ClampCarPosition()
    {
        Vector3 carPosition = transform.position;

        // Get bounds of the road collider
        Collider roadCollider = GameObject.FindGameObjectWithTag("Road").GetComponent<Collider>();
        Bounds roadBounds = roadCollider.bounds;

        // Clamp car position within the road bounds
        float xClamp = Mathf.Clamp(carPosition.x, roadBounds.min.x, roadBounds.max.x);

        // Check if the car is near the road boundary
        bool nearBoundaryX = carPosition.x < roadBounds.min.x + 1f || carPosition.x > roadBounds.max.x - 1f;

        // Apply a sliding force if the car is near a boundary
        if (nearBoundaryX)
        {
            float forceX = (xClamp - carPosition.x) * speed;
            rb.AddForce(Vector3.right * forceX);
        }

        carPosition = new Vector3(xClamp, carPosition.y, carPosition.z);

        // Update car's position
        transform.position = carPosition;
    }
}
