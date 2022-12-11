using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Range(0.0f, 200)]
    public float Health = 100;
    public void TakeDamage(float damage)
    {
        Health -= damage;
    }
}
