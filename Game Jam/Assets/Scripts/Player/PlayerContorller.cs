using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorller : MonoBehaviour
{
    [Header("Movment")]
    public float speed;
    public float pickupcount;


    [Header("Collider")]
    public GameObject money;
    public BoolObject Bool;

    void Start()
    {
        
    }

    void Update()
    {
        
        


    }


    void OnTriggeEnter(Collider other)
    {

        if(other.tag == "money")
        {

            

        }

    }

}
