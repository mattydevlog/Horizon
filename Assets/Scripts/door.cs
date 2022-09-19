using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class door : MonoBehaviour
{

    public Rigidbody door1;

    public BoxCollider doorHitbox;

    public GameObject player1;

    bool hasEntered;

    float speed = 500f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player1)
        {
            hasEntered = true;
            Debug.Log("enter");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == player1)
        {
            hasEntered = false;
            Debug.Log("cant enter");
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (hasEntered)
        {
            door1.velocity = ((transform.right) * speed) * Time.fixedDeltaTime;
        }

    }
}
