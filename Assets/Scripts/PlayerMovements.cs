using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public Rigidbody rbody;
    public float speed = 5f;

    private void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rbody.MovePosition(transform.position + m_Input * Time.deltaTime * speed);
    }

}
