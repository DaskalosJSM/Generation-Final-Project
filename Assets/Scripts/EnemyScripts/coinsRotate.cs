using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsRotate : MonoBehaviour
{
    public float rotationSpeed = 5;
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
