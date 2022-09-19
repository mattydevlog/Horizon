using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class pickUp : MonoBehaviour
{

    public ParticleSystem ParticleSystem;

    public Transform spawnPoint;

    public GameObject player1;

    bool hasEntered;

    static int inventoryValue;


    public Text ValueText;


    // Start is called before the first frame update
    void Start()
    {

        ValueText.text = inventoryValue.ToString();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player1)
        {
            hasEntered = true;

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == player1)
        {
            hasEntered = false;

        }

    }


    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.E) && hasEntered)
        {


            {
                Destroy(gameObject);
                Instantiate(ParticleSystem, transform.position, Quaternion.identity);
                ParticleSystem.Play();

                Inventory();
            }

        }

        void Inventory()
        {

            inventoryValue += 1;
            ValueText.text = inventoryValue.ToString();
            Debug.Log(inventoryValue);
        }
    }


}

