using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Character2DController : MonoBehaviour

{

    public float speed;

    public float NormalVitess = 5f;

    public float DashVitess = 10f;

    public float jumpAmount = 5.0f;

    public bool isOnGround = true;

    private float horizontalInput;

    private float fowardInput;

    private Rigidbody playerRb;



    void Start()

    {

        playerRb = GetComponent<Rigidbody>();

    }





    void Update()

    {

        // get player input 

        horizontalInput = Input.GetAxis("Horizontal");

     


        // Move the player foward

     

        transform.Translate(Vector3.forward * Time.deltaTime * speed * horizontalInput);



        // Let the player jump 

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)

        {

            playerRb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);

            isOnGround = false;

        }

    }

    private void OnCollisionEnter(Collision collision)

    {

        if (collision.gameObject.CompareTag("Ground"))

        {

            isOnGround = true;

        }

    }

}

