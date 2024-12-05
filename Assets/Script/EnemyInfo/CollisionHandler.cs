using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the "EnemyMovement" component
        EnemyMovement enemy = collision.gameObject.GetComponent<EnemyMovement>();
        if (enemy != null)
        {
            enemy.ReverseDirection(); // Reverse the enemy's direction
        }
    }
}
