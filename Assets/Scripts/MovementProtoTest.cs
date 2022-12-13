using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementProtoTest : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float rotationSpeed;

    public float speed;

    [Header("Attacking")]
    public LayerMask whatIsEnemy;
    public bool alreadyAttacked;
    public float attackRange;
    public bool enemyInAttackRange;
    public float timeBetweenAttacks;
    public GameObject hitBox;
    public float damageEnenmies;
    public GameObject projectile;
    //[Header("Detection")]
    //public EnemyStats enemyStats;
    //public GameObject enemy;
    // Update is called once per frame
    void Update()
    {
        // Atack Range
        enemyInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsEnemy);
        if (enemyInAttackRange && alreadyAttacked == false) AttackEnemy();
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
    void AttackEnemy()
    {
            ///Attack code here
            //enemyStats = enemy.GetComponent<EnemyStats>();
            
            MeeleEnemyAttack();
            ///End of attack code
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    public void MeeleEnemyAttack()
    {
        hitBox.SetActive(true);
        Invoke("DeactivateHitBox", 1.0f);
        //enemyStats.TakeDamage(25);
    }
     public void DeactivateHitBox()
    {
        hitBox.SetActive(false);
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
