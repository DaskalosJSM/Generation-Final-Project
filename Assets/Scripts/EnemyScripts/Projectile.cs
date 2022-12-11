using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Lifetime = 8f;
    public float coutdown = 5f;
    public float speed = 20f;
    public float damagePlayer = 25;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coutdown = Lifetime;
        rb.velocity = speed * transform.forward;
    }

    void Update()
    {
        coutdown -= Time.deltaTime;
        if (coutdown <= 0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats player = other.gameObject.GetComponent<PlayerStats>();
            player.TakeDamage(damagePlayer);
            Destroy(gameObject);
        }
    }
}
