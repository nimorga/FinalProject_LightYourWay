using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDamage : MonoBehaviour
{
    public float attackDamage = 1f;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeEnemyDamage(attackDamage); 
                Destroy(gameObject); 
            }
        }
    }
}

