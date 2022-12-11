using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public PlayerStats player;

    [Header("Enemy Stats")]
    [Range(0.0f, 100)]
    public float health ;
    public bool RangeEnemy;

    [Header("Attacking")]
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public GameObject hitBox;
    public float damagePlayer;
    public GameObject projectile;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerStats>();
    }
    public void Attack()

    {
        if (RangeEnemy)
        {
            if (!alreadyAttacked)
            {
                ///Attack code here
                Shoot();
                ///End of attack code
                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }
        else if (!RangeEnemy)
        {
            if (!alreadyAttacked)
            {
                ///Attack code here
                MeeleEnemyAttack();
                ///End of attack code
                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Invoke(nameof(DestroyEnemy), 1.5f);
        }
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    public void Shoot()
    {
        Instantiate(projectile, this.transform.position, this.transform.rotation);
    }
    public void MeeleEnemyAttack()
    {
        hitBox.SetActive(true);
        Invoke("DeactivateHitBox", 1.0f);
    }
    public void DeactivateHitBox()
    {
        hitBox.SetActive(false);
        player.TakeDamage(damagePlayer);
    }

}
