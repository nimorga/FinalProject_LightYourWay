using UnityEngine;

public class HandleDamage : MonoBehaviour
{
    [SerializeField] public float attackDamage = 1f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }
}


