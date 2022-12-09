using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementProtoTest : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    public float speed;
    // Update is called once per frame
    void Update()
    {
        //Movement Input

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Input
        if (horizontalInput != 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        }
        if (verticalInput != 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        }
    }
}
