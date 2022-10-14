using Cinemachine;
using Cinemachine.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class CharacterController3D : MonoBehaviour
{
    public float speed;
    public float DashSpeed = 35f;
    public float NormalSpeed = 5f;

    public float jumpAmount = 5.0f;

    public bool isOnGround = true;

    private float horizontalInput;

    private float fowardInput;

    private Rigidbody playerRb;

    public CinemachineVirtualCamera came;



    void Start()

    {

        playerRb = GetComponent<Rigidbody>();
        came.GetComponent<CinemachineFollowZoom>();

    }





    void Update()

    {

        // get player input 

        horizontalInput = Input.GetAxis("Horizontal");

        fowardInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = DashSpeed;
            print("Running");
            came.GetComponent<CinemachineFollowZoom>().m_Width = 3;                                                                             
        }
        else
        {
            speed = NormalSpeed;
            came.GetComponent<CinemachineFollowZoom>().m_Width = 10;
        }



        // Move the player foward

        transform.Translate(Vector3.forward * Time.deltaTime * speed * fowardInput);

        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);



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