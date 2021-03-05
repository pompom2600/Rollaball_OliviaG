using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
   

    void Start()
    {
    
        
    }

    
    void Update()
    {
        Vector3 turn = new Vector3(15, 50, 0) * Time.deltaTime;

       transform.Rotate(turn);




    }
}
