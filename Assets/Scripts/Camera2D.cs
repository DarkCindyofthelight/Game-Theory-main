using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : MonoBehaviour
{

    public GameObject player;

    public float horizontal = 2f;

    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {


        Vector3 Offset = new Vector3(5,1, horizontal);
        transform.position = player.transform.position + Offset;
        
    }
}
