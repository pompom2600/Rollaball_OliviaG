using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Display : MonoBehaviour
{
    public Text DisplayText;
    private int Count;
    private bool Reverse;
    public Color OtherColour;




    void Start()
    {
        DisplayText.text = " potato";
    }

    void Update()
    {

        if (Reverse == false)
        {


            Count = Count + 1;
            
            DisplayText.color = OtherColour;
            DisplayText.text = "count = " + Count;

        }

        else
        {

            Count = Count - 1 ;
          
            DisplayText.color = Color.magenta;
            DisplayText.text = "count = " + Count;
        }

        if (Count >= 100)
        {
            Reverse = true;

        }

        else if (Count <= 0)
        {
            Reverse = false;

        }

        /*if (Count < 100)
        {
            Count = Count + 1;

            DisplayText.text = "count = " + Count;

            if (Count == 100)
            {

                DisplayText.text = "omg u did it whoo!";

    }
    }*/

    }
}
