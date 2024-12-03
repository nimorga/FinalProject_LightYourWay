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
    private Camera mainCamera;

    void Start(){
        mainCamera = Camera.main;
    }


    void Update () {

        // Basic Movement
        if(IsOnScreen()){
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
    }

    void FixedUpdate () {
        // Random direction changes are not time-based due to FixedUpdate()
        if (IsOnScreen() && Random.value < changeDirChance) {
            speed *= -1;    // Change Direction
        }  
    }

    //Makes sure enemy is on screen
    private bool IsOnScreen(){
        if(mainCamera == null) return false;
        Vector3 viewport = mainCamera.WorldToViewportPoint(transform.position);
        return viewport.x >= 0 && viewport.x <= 1 && viewport.y>= 0 && viewport.y <=1;
    }
}
