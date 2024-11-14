using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandMagic : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public GameObject magicPrefab;
    public Transform wand;
    public float magicSpeed = 10f;
    public float destroyTime = 0.5f;
    private float horizontalInput;

    // Update is called once per frame
    void Update()
    {
        //Get the horizontal input for movement
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.E)){
            ShootMagic();
        }
    }

    void ShootMagic()
    {
        if (magicPrefab != null && wand != null)
        {
            //Prefab at the wand's position and rotation
            GameObject magic = Instantiate(magicPrefab, wand.position, wand.rotation);
            Rigidbody2D rb = magic.GetComponent<Rigidbody2D>();//Get 2D projectile

            if (rb != null)
            {
                rb.gravityScale = 0f;//to prevent gravity
                Vector2 magicDirection;

                //Check direction
                if (horizontalInput > 0){
                    magicDirection = Vector2.right;
                }
                else if (horizontalInput < 0){
                    magicDirection = Vector2.left;
                }
                else{
                    magicDirection = Vector2.right;
                }
                rb.velocity = magicDirection * magicSpeed;//Move the magic projectile in the calculated direction

                //Destroy the magic
                Destroy(magic, destroyTime);
            }
        }
    }
}



