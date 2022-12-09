using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementProtoTest : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float rotationSpeed;

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
            this.transform.RotateAround(this.transform.position, Vector3.up, horizontalInput * rotationSpeed);
        }
        if (verticalInput != 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput, this.transform);
        }
    }
}
