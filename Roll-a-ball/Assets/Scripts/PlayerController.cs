using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //UI things
    [Header("UI Stuff")]
    public GameObject gameOverScreen;
    public Text countText;
    public Text winText;

    //MovementControls
    public Rigidbody rb;
    public float jumpForce;
    public float MoveSpeed = 2;
    int count;

    //FallZone
    GameObject resetPoint;
    bool resetting = false;
    Color originalColour;

    //Pickups
    private int pickupCount;

    //Controllers
    GameController gameController;
    Timer timer;

    //Jumppad
    bool grounded = false;
    
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        count = 0;
        pickupCount = GameObject.FindGameObjectsWithTag("Pickup").Length;
        gameOverScreen.SetActive(false);
        
        winText.text = "";

        //FallZone
        resetPoint = GameObject.Find("Reset Point");
        originalColour = GetComponent<Renderer>().material.color;

        //Timerfunction
        gameController = FindObjectOfType<GameController>();
        timer = FindObjectOfType<Timer>();
        print("Timer = " + timer.name);
        print("GC = " + gameController.name);
        if (gameController.gameType == GameType.SpeedRun)
            StartCoroutine(timer.StartCountdown());

        SetCountText();

    }

    
    void FixedUpdate()
    {
        //Timerfunction
        if (gameController.gameType == GameType.SpeedRun && !timer.IsTiming())
            return;

        //FallZone
        if (resetting)
            return;

        if (Input.GetKeyDown("space"))
        {

            rb.AddForce(Vector3.up * jumpForce);

        }
        float x = Input.GetAxis("Horizontal") * MoveSpeed;
        float z = Input.GetAxis("Vertical") * MoveSpeed;
        rb.AddForce(x, 0, z);

        //Jumppad
        if (grounded)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement * MoveSpeed);

        }

    }
   
    private void OnCollisionStay(Collision collision)
    {
        //Jumppad
        if (collision.collider.CompareTag("Ground"))
            grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        //Jumppad
        if (collision.collider.CompareTag("Ground"))
            grounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //FallZone
        if(collision.gameObject.CompareTag("Respawn"))
        {
            StartCoroutine(ResetPlayer());
        }

    }

    public IEnumerator ResetPlayer()
    {
        resetting = true;
        GetComponent<Renderer>().material.color = Color.black;
        rb.velocity = Vector3.zero;
        Vector3 startPos = transform.position;
        float resetSpeed = 2f;
        var i = 0.0f;
        var rate = 1.0f / resetSpeed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(startPos, resetPoint.transform.position, i);
            yield return null;
        }
        GetComponent<Renderer>().material.color = originalColour;
        resetting = false;
    }

    //Pickup things
    private void OnTriggerEnter(Collider other)
    {

        print("Strawberry");

        if (other.tag == "Pickup")
        {

            print("Chocolate");
            Destroy(other.gameObject);
            count = count + 1;
            SetCountText();
        }


    }


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= pickupCount)
        {
            //WinGame();
            
            gameOverScreen.SetActive(true);
            winText.text = "You Win!";

            //SpeedRun
            if (gameController.gameType == GameType.SpeedRun)
                timer.StopTimer();
        }

        
        

    }

    /*void WinGame()
    {


        gameOverScreen.SetActive(true);
        winText.text = "You Win!";

    }
    */



}
