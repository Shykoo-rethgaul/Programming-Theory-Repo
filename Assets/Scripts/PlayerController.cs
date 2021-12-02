using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 20.0f;

    private int playerHealth;
    private int fruitCollected = 0;

    private float jumpForce = 600;
    private float gravityModifier = 5.0f;
    private float xRange = 11.81f;
    private float yRange = 0.59f;

    public bool isOnGround = true;
    public bool gameOver = false;
    public bool iFrames = false;
   
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerHealth();
        ConstrainPlayerMovement();
        
    }
    void ConstrainPlayerMovement()
    {
        //sets leftmost bounds for player
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        //sets rightmost bounds for player
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        //sets lowest position
        if (transform.position.y < yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
    }
    void PlayerMovement()
    {
        //moves player left and right using arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //makes player jump when pressing space as long as they're on the ground and the game is not over
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //checks if the player is on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        // if player touches enemy damage the player
        if (collision.gameObject.CompareTag("Horizontal Enemy") || collision.gameObject.CompareTag("Vertical Enemy"))
        {
            /*need to add a way for player to not be able to take a hit for a few seconds after being hit
              also need a way to bounce players back from enemies on contact */

            
            playerHealth -= 1;
            Debug.Log("Player hit! " + playerHealth + " health remaining.");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Fruit"))
        {
            fruitCollected += 1;
            Debug.Log("Got a fruit! You have collected " + fruitCollected + " so far!");
            Destroy(other.gameObject);
        }
    }
    public void PlayerHealth()
    {
        if (playerHealth == 0)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
