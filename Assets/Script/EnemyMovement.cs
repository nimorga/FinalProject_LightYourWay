using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Inscribed")]
    // Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    void Update () {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed);   // Move Right
        } else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed);  // Move Left
        }

        // Flip the character based on direction
        if (speed > 0) {
            // Moving right: set rotation Y to 0
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } else {
            // Moving left: set rotation Y to 180
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void FixedUpdate () {
        // Random direction changes are not time-based due to FixedUpdate()
        if (Random.value < changeDirChance) {
            speed *= -1;    // Change Direction
        }  
    }
}
