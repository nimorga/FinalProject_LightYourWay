using UnityEngine;

public class HandleDamage : MonoBehaviour
{
    [SerializeField] public float attackDamage = 1f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))//If find a compare tag of Enemy 
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }
}


