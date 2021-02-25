using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goodbye_World : MonoBehaviour
{
    // Start is called before the first frame update

    public int PlayerHealth = 100;
    float PlayerTime = 0.10f;
    string PlayerName = "BigBen205";
    bool Dead = false;



    void Start()
    {
   if (PlayerHealth > 0)
        {
            Debug.Log(Dead);

        }
        else
        {

            Debug.Log("Dead lmao");
            Dead = true;


        }

    }

    // Update is called once per frame
    void Update()
    {

    }


    void Potato()
    {

        Debug.Log("Fries or Chips?!");



    }
}
