using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float horizontalInput;
    public float speed = 7.5f;
    
    private float minRange1 = -4.0f;
    private float maxRange1 = 4.0f;
    
    private float minRange2 = 71.0f;
    private float maxRange2 = 79.0f;

    public float jumpForce = 25;
    public float gravityModifier = 4;
    public bool isOnGround = true;

    private Rigidbody playerRb;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public GameObject player;

    void Start()
    {
    
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    
    }
    
    void Update()
    {
        
        if (player.CompareTag("Player1")) {
        
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        
        }

        if (transform.position.x > maxRange1 && player.CompareTag("Player1")) {
        
            transform.position = new Vector3(maxRange1, transform.position.y, transform.position.z);

        }
        else if (transform.position.x < minRange1 && player.CompareTag("Player1")) {
        
            transform.position = new Vector3(minRange1, transform.position.y, transform.position.z);

        }

        if(Input.GetKeyDown(KeyCode.Space) && player.CompareTag("Player1") && isOnGround){
        
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        
        }



        if (transform.position.x > maxRange2 && player.CompareTag("Player2")) {
        
            transform.position = new Vector3(maxRange2, transform.position.y, transform.position.z);

        }
        else if (transform.position.x < minRange2 && player.CompareTag("Player2")) {
        
            transform.position = new Vector3(minRange2, transform.position.y, transform.position.z);

        }

        if(Input.GetKeyDown(KeyCode.Z) && player.CompareTag("Player2") && isOnGround){
        
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        
        }

    }

    void TakeDamage(int damage) {
    
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

    }

    private void OnCollisionEnter(Collision collision) {
    
        isOnGround = true;

    }

    void OnTriggerEnter(Collider other) {
    
        Destroy(other.gameObject);
        
        TakeDamage(5);

    }

}
