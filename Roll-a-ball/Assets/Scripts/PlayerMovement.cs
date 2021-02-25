using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody Rb;
    public float jumpForce;
    public float MoveSpeed = 2;


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
}
