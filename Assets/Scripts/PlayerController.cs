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

        rb.MovePosition(rb.position + forwardMovement + horizontalMovement);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalDirection = Input.GetAxis("Horizontal");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coin")
        {
            gameManager.IncreaseScore();

            GameObject g = Instantiate(coinEffect, transform.position, Quaternion.identity);
            Destroy(g, 2);
            Destroy(other.gameObject);
        }
    }
}
