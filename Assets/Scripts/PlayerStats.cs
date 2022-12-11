using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
  public float Health = 100;
  public void TakeDamage(int damage)
  {
    Health -= damage;
  }
}
