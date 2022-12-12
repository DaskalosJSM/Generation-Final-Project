using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEnemyElements : MonoBehaviour
{
    public EnemyStats enemyStats;
    public Camera my_camera;
    SpriteRenderer Spritecolor;
    public GameObject healthBar;
    void Awake()
    {
        my_camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        enemyStats = GetComponent<EnemyStats>();
    }
    void Update()
    {
        Billboard();
        healthBar.transform.localScale = new Vector3(enemyStats.health/1000, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        if (enemyStats.health<=0) Destroy(this.gameObject);
    
    }
    void Start()
    {
        Spritecolor = healthBar.GetComponent<SpriteRenderer>();
        Spritecolor.color = Color.green;
    }
    private void FixedUpdate()
    {

        if (enemyStats.health <= 50) Spritecolor.color = Color.yellow;
        if (enemyStats.health <= 25) Spritecolor.color = Color.red;

    }
    // Update is called once per frame
    void TakeDamage(float damage)
    {
        enemyStats.health -= damage;
    }
    void Billboard()
    {
        healthBar.transform.LookAt(healthBar.transform.position + my_camera.transform.rotation * Vector3.back,
        my_camera.transform.rotation * Vector3.up);
    }
}
