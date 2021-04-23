using System.Collections;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    //Teleporter
    public Vector3 rotationAxis;
    public float rotationSpeed;
    
    /*//General Rotation
    public float waitTime = 5;
    public float speed = 10;
    bool rotated = false;
    Vector3 startRotation;
    public Vector3 toRotation = new Vector3(0, 90, 0);

    //General Rotation
    public void Start()
    {
        startRotation = transform.eulerAngles;
        StartCoroutine(Rotate());
    }

    IEnumerable Rotate()
    {
        Vector3 newRot = rotated ? startRotation : toRotation;
        var toAngle = Quaternion.Euler(newRot);
        while (transform.rotation != toAngle)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toAngle, speed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(waitTime);
        rotated = !rotated;
        StartCoroutine(Rotate());
    }
    */
    // Teleporter
    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
