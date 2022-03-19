using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    void Update()
    {
        if (transform.poistion.y < -10)
        {
            Destroy(gameObject); 
        }
    }

    void OnTriggerEnter(Collider Other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject); 
        }
        Destroy(gameObject); 
        
    }
}
