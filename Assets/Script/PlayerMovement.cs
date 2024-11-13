using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] private float speed;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float jumpForce;  // New variable for jump height
    [SerializeField] private Transform wand;
    [SerializeField] private float wandOffset = 0.5f;
    [SerializeField] private float wandSetY = 0.001f;

    private Rigidbody2D body;
    private Animator anim;
    private float cooldownTimer = Mathf.Infinity;
    private Vector3 originalWandPosition; //To get og wand pos


    private void AdjustWand(int direction)
    {
        if (wand != null)
        {
            //Adjust wand
            if (direction > 0)//Right
            {
                wand.localRotation = Quaternion.Euler(0, 0, 90); //Rotate 90
                wand.localPosition = new Vector3(wandOffset, -wandSetY, 0); //Move wand
            }
            else//Left
            {
                wand.localRotation = Quaternion.Euler(0, 0, -90); //Rotate 90
                wand.localPosition = new Vector3(wandOffset, -wandSetY , 0); //Move wand
            }
        }
    }

    private void ResetWandPosition()
    {
        if (wand != null)
        {
            //Return to original position
            wand.localPosition = originalWandPosition;
            wand.localRotation = Quaternion.Euler(0, 0, 15);
        }
    }

    private void Awake()
    {
        // Grab references for Rigidbody and Animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        originalWandPosition = wand.localPosition;//Store wand pos
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flip player when moving left-right
        if (horizontalInput > 0.01f){
            AdjustWand(1);
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f){
            AdjustWand(-1);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else{
            ResetWandPosition();
        }
        // Jump logic
        if (Input.GetKey(KeyCode.Space) && cooldownTimer > jumpCooldown)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);  // Use jumpForce for the vertical velocity
            cooldownTimer = 0;
        }

        cooldownTimer += Time.deltaTime;

        // Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
    }

}
