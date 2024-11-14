using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]public float maxHealth = 20f;
    public float currentHealth;
   
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeEnemyDamage(float damage){
        currentHealth -= damage;
        if(currentHealth <= 0){
            Destroy(gameObject);
        }
    } 
}
