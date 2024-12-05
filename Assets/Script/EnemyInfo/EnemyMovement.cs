using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = -2.0f; // Movement speed of the enemy (default moving left)
    private Vector2 direction = Vector2.left; // Direction multiplier

    void Update()
    {
        // Move the enemy
        transform.Translate(direction * Mathf.Abs(speed) * Time.deltaTime);

        // Adjust rotation to face the opposite direction of movement
        if (speed > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // Face left when moving right
        }
        else if (speed < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); // Face right when moving left
        }
    }

    public void ReverseDirection()
    {
        speed = -speed; // Reverse the movement speed
    }
}
