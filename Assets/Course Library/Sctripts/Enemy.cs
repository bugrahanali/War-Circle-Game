using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRB;
    public float speed;
    private GameObject player;  
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
       
       }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10 )
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        enemyRB.AddForce((player.transform.position - transform.position).normalized * speed);

    }
}
