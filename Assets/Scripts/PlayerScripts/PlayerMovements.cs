using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public Rigidbody rbody;
    public float speed = 5f;
    private float horizontalInput;
    private float verticalInput;
    public float rotationSpeed = 5f;

    [Header("Attacking")]
    public LayerMask whatIsEnemy;
    public bool alreadyAttacked;
    public float attackRange;
    public bool enemyInAttackRange;
    public Collider[] enemyInRange;
    public float timeBetweenAttacks;
    public GameObject hitBox;

    private void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
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
    void Update()
    {
        // Atack Range
        enemyInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsEnemy);
        enemyInRange = Physics.OverlapSphere(transform.position, attackRange, whatIsEnemy);
        if (enemyInAttackRange && alreadyAttacked == false) AttackEnemy();
    }
    void AttackEnemy()
    {
        ///Attack code here
        //enemyStats = enemy.GetComponent<EnemyStats>();
        transform.LookAt(enemyInRange[0].gameObject.transform);
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
