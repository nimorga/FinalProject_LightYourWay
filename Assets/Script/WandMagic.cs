using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandMagic : MonoBehaviour
{
    public GameObject magicPrefab;
    public Transform wand;
    public float magicSpeed = 10f;
    public float destroyTime = 0.5f;
    public float attackCooldown;
    private float cooldownTimer;
    
    // Store the last direction the player pressed
    private Vector2 lastDirection = Vector2.right; // Default to right (D key)

    void Update()
    {
        // Check for direction key presses
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lastDirection = Vector2.left; // If 'A' is pressed, the last direction is left
        }
        else if (Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.RightArrow))
        {
            lastDirection = Vector2.right; // If 'D' is pressed, the last direction is right
        }

        // If the player presses 'E' and the cooldown is over, shoot in the last direction
        if (Input.GetKeyDown(KeyCode.E) && cooldownTimer >= attackCooldown)
        {
            ShootMagic(lastDirection);
            cooldownTimer = 0f; // Reset the cooldown timer
        }

        // Increment cooldown timer
        cooldownTimer += Time.deltaTime;
    }

    void ShootMagic(Vector2 direction)
    {
        if (magicPrefab != null && wand != null)
        {
            GameObject magic = Instantiate(magicPrefab, wand.position, wand.rotation);
            Rigidbody2D rb = magic.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.gravityScale = 0f;
                rb.velocity = direction * magicSpeed; // Shoot the magic in the last remembered direction
                Destroy(magic, destroyTime);
            }
        }
    }
}
