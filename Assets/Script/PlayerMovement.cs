using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] private float speed;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float jumpForce;  // New variable for jump height

    private Rigidbody2D body;
    private Animator anim;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        // Grab references for Rigidbody and Animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flip player when moving left-right
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

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
