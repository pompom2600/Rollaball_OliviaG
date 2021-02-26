using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody Rb;
    public float jumpForce;
    public float MoveSpeed = 2;
    int score = 0;


    void Start()
    {
        Rb = GetComponent<Rigidbody>();

    }

 
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {

            Rb.AddForce(Vector3.up * jumpForce);
             
        }
        float x = Input.GetAxis("Horizontal") * MoveSpeed;
        float z = Input.GetAxis("Vertical") * MoveSpeed;
        Rb.AddForce(x, 0, z);

    }


    private void OnTriggerEnter(Collider other)
    {

        print("Strawberry");
        
        if (other.tag == "Pickup")
        {

            print ("Chocolate");
            Destroy(other.gameObject);
            score = score + 1;
            print("Score is " + score);

            if (score == 8)
            {

                print("Winner Winner Chicken Dinner");

            }

        }
   

    }

}
