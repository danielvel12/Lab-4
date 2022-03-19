using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private float speed = 20.0f; 
    private float turnSpeed = 120.0f; 

    private float horizontalInput; 
    private float forwardInput;

    private float xRange = 25.0f; 
    private float zRange = 25.0f; 

    public int maxHealth = 3; 
    public int health { get {return currentHealth; }}
    int currentHealth = 3; 
    public float timeInvincinble = 2.0f; 
    bool isInvincible; 
    float isInvincibleTimer; 

    public GameObject projectile;   

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Health: " + currentHealth + "/" + maxHealth); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shot = Instantiate(projectile, transform.position + (transform.forward * 2), 
            shot.GetComponent<Rigidbody>().AddForce(transform.forward * 2000)); 
        }
        
        horizontalInput = Input.GetAxis("Horizontal"); 
        forwardInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z); 
        } 
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.postion.y, transform.postion.z); 
        }
        if (transform.positon.z < -zRange)
        {
            transform.positon = new Vector3(transform.position.x, transform.positon.y, -zRange); 
        }
        else if (transform.postion.z > zRange)
        {
            transform.postion = new Vector3(transform.positon.x, transform.postion.y, zRange); 
        }

        if (isInvincible)
        {
            invincibleTime -= Time.deltaTime; 
            if (invincibleTime < 0)
                isInvincible = false; 
        }
    }
    public void ChangeHealth(int amount)
    {
        if (amount < 0) 
        {
            if (isInvincible)
                return; 
            
            isInvincible = true; 
            invincibleTimer = timeInvincinble; 
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth); 
        Debug.Log("Health: " + currentHealth + "/" + maxHealth); 
    }
}