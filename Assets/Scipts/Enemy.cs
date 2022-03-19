using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody enemyRb: 
    public float speed = 3.0f; 
    int MoveDist = 20; 
    int AttackDist = 5; 
    GameObject plaey; 
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>(); 
        player = GameObject.Find("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position); 

        if(Vector3.Distance(transform.position, player.transform.postion) <= MoveDist)
        {
            Vector3 postion = Vecotr3.MoveToawrds(transform.postion, 
                player.transform.postion, speed * Time.deltaTime); 
            enemyRb.MovePostion(position); 

            if(Vector3.Distance(transform.postion, player.transform.postion) <= AttackDist)
            {
                Debug.Log("Attack Distance Achieved!!!"); 
            }
        }

        if (transform.postion.y < -10)
        {
            Destroy(gameObject); 
        }
    }

    void OnCollisionEnter(Collision other)
    {
        PlayerController1 player = other.gameObject.GetComponent<PlayerController1>(); 

        if (player != null)
        {
            player.ChangeHealth(-1); 
        }
    }
}
