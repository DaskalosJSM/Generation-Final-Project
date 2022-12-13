using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Range(0.0f, 200)]
    public float Health;
    public GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        if (Health <= 0)
        {
            gameManager.GameOver();
        }
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
    }
    public void Addlife(float life)
    {
        Health += life;
    }
}
