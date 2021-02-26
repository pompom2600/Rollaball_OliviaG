using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{

    public GameObject Player;
    private Vector3 Offset;
 
    void Start()
    {

        Offset = transform.position - Player.transform.position;




    }


    void LateUpdate()
    {

        transform.position = Player.transform.position + Offset;
        




    }
}
