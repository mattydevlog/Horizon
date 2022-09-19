using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementPlayer : MonoBehaviour
{
    [SerializeField]
    Rigidbody player1;
    [SerializeField]
    float movementSpeed = 5f;


    void Start()
    {
        player1 = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {


        if (Input.GetKey(KeyCode.W))
        {
            player1.velocity = (transform.forward) * movementSpeed * Time.fixedDeltaTime;
          
        }
        if (Input.GetKey(KeyCode.S))
        {
            player1.velocity = (-transform.forward) * movementSpeed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            player1.velocity = (-transform.right) * movementSpeed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            player1.velocity = (transform.right) * movementSpeed * Time.fixedDeltaTime;
        }
    }
}
