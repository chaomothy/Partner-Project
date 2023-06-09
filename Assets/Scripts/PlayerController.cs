using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float horizontalInput;
    public float horizontalInput2;

    public float speed = 7.5f;
    
    private float minRange1 = -4.0f;
    private float maxRange1 = 4.0f;
    
    private float minRange2 = 71.0f;
    private float maxRange2 = 79.0f;

    public float jumpForce = 25;
    public bool isOnGround = true;

    private Rigidbody playerRb;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public GameObject player;

    public GameManager gameManager;


    void Start()
    {
    
        playerRb = GetComponent<Rigidbody>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        InvokeRepeating("DamageOverTime", 1.0f, 0.25f);
    
    }
    
    void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        horizontalInput2 = Input.GetAxis("Horizontal2");
        
        if (player.CompareTag("Player1")) {
        
            if(Input.GetKey(KeyCode.D)) {
            
                transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

            }

            if(Input.GetKey(KeyCode.A)) {
            
                transform.Translate(Vector3.left * -horizontalInput * Time.deltaTime * speed);

            }
            
            
            if (transform.position.x > maxRange1) {
        
            transform.position = new Vector3(maxRange1, transform.position.y, transform.position.z);

            }
            else if (transform.position.x < minRange1) {
        
            transform.position = new Vector3(minRange1, transform.position.y, transform.position.z);

            }

            if(Input.GetKeyDown(KeyCode.Space) && isOnGround){
        
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

            }
        }


        if (player.CompareTag("Player2")) {
        
            if(Input.GetKey(KeyCode.RightArrow)) {
            
                transform.Translate(Vector3.right * horizontalInput2 * Time.deltaTime * speed);

            }

            if(Input.GetKey(KeyCode.LeftArrow)) {
            
                transform.Translate(Vector3.left * -horizontalInput2 * Time.deltaTime * speed);

            }


            if (transform.position.x > maxRange2 && player.CompareTag("Player2")) {
        
                transform.position = new Vector3(maxRange2, transform.position.y, transform.position.z);

            }

            else if (transform.position.x < minRange2 && player.CompareTag("Player2")) {
        
                transform.position = new Vector3(minRange2, transform.position.y, transform.position.z);

            }

            if(Input.GetKeyDown(KeyCode.Keypad4) || (Input.GetKeyDown(KeyCode.Alpha4)) && player.CompareTag("Player2") && isOnGround){
        
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;




            }
        }
        
        if(Input.GetKeyDown(KeyCode.Return)) 
        {
        
            gameManager.RestartGame();

        }

        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
        
            gameManager.ExitToMenu();
        
        }

    }

    void TakeDamage(int damage) {
    
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth < 1 && player.CompareTag("Player2")){
        
            FindObjectOfType<GameManager>().EndGame1();
        
        }

        if(currentHealth < 1 && player.CompareTag("Player1")){
        
            FindObjectOfType<GameManager>().EndGame2();
        
        }

    }

    void DamageOverTime() {
    
        TakeDamage(1);
    
    }

    void Heal(int healing) {
    
        currentHealth += healing;
        healthBar.SetHealth(currentHealth);

        if(currentHealth > maxHealth) {
        
            currentHealth = maxHealth;

        }

    }

    private void OnCollisionEnter(Collision collision) {
    
        isOnGround = true;
        

    }

    void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.CompareTag("PowerUp")) 
        {
        
            Destroy(other.gameObject);

            Heal(10);
            
        }
        else 
        {
        
            Destroy(other.gameObject);
        
            TakeDamage(5);

        }

    }

}
