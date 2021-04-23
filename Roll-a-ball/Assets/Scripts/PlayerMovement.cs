using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody Rb;
    public float jumpForce;
    public float MoveSpeed = 2;
    int score = 0;
    public Text DisplayText;
    public Color WinningColour;





    void Start()
    {
        Rb = GetComponent<Rigidbody>();

    }

 
    void FixedUpdate()
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
            DisplayText.text = "Count = " + score;

            if (score == 8)
            {

                DisplayText.text = " You Win Yay! ";
                DisplayText.color = WinningColour;
            }

        }
   

    }

}
