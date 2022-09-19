using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class pickUp : MonoBehaviour
{
    public Item Item;

    public GameObject shroom;

    public ParticleSystem ParticleSystem;

    public Transform spawnPoint;

    public GameObject player1;

    bool hasEntered;

    static int inventoryValue;


    private Text ValueText;

    //  ValueText.text = inventoryValue.ToString();
    // Start is called before the first frame update
    void Start()
    {


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
               
                
                Instantiate(ParticleSystem, transform.position, Quaternion.identity);
                ParticleSystem.Play();

                Inventory();
            }

        }

         void Inventory()
        {
            Destroy(shroom);
            InventoryManager.Instance.Add(Item);
            // inventoryValue += 1;
            //   ValueText.text = inventoryValue.ToString();
            // Debug.Log(inventoryValue);
        }
    }


}

