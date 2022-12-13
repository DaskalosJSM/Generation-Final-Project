using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public PlayerStats player;

    [Header("Enemy Stats")]
    [Range(0.0f, 100)]
    public float health;
    public bool RangeEnemy;
    public Rigidbody rb;

    [Header("Attacking")]
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public GameObject hitBox;
    public float damagePlayer;
    public GameObject projectile;
    public float trhust = 20;

    [Header("ParticleCoins")]
    public GameObject prefabCoin;
     public GameObject prefabLife;
    public float coinsCuantity;

    private void Awake()
    {
    }
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody>();
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
        rb.AddRelativeForce(Vector3.back * trhust, ForceMode.Impulse);
        health -= damage;
        if (health <= 0)
        {
            Invoke(nameof(DestroyEnemy), 1.5f);
        }
    }
    public void TakebulletDamage(int damage)
    {
        rb.AddRelativeForce(Vector3.back * trhust / 10, ForceMode.Impulse);
        health -= damage;
        if (health <= 0)
        {
            Invoke(nameof(DestroyEnemy), 1.5f);
        }
    }
    public void DestroyEnemy()
    {
        int index;
        index = Random.Range(1,5);
        if (index==3)
        {
            Instantiate(prefabLife, this.transform.position, Quaternion.identity);
        }
        for (int i = 0; i < coinsCuantity; i++)
        {
            Vector3 posInicial = new Vector3(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(0f, 2f), transform.position.z + Random.Range(-2f, 2f));
            Instantiate(prefabCoin, posInicial, Quaternion.identity);
            prefabCoin.GetComponent<Rigidbody>().AddForce(Random.Range(-4f, 4f), Random.Range(-4f, 4f), Random.Range(-4f, 4f), ForceMode.Impulse);
        }
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
