using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float horizontalInput;
    public float speed = 7.5f;
    public float xRange = 4.0f;

    public float jumpForce = 25;
    public float gravityModifier = 4;
    public bool isOnGround = true;

    private Rigidbody playerRb;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
    
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    
    }
    
    void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (transform.position.x > xRange) {
        
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        }
        else if (transform.position.x < -xRange) {
        
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);

        }

        if(Input.GetKeyDown(KeyCode.W) && isOnGround){
        
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
