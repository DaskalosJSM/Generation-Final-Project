using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public float startSpeed = 1f;

    [HideInInspector]
    public float speed;
    public float startHealth = 100;
    private float healt;

    public int value = 5;

    public GameObject deathEfect;

    [Header("Unity Stufs")]

    private Transform target;
    //private int wavepointIndex = 0;

    private void Start()
    {
        speed = startSpeed;
        healt = startHealth;
    }

    public void TakeDamage(float amount)
    {
        healt -= amount;
        if (healt <= 0)
            Die();
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {

        //GameObject effect = (GameObject)Instantiate(deathEfect, transform.position, Quaternion.identity);
        //Destroy(effect, 1f);

        Destroy(gameObject);
    }
}
