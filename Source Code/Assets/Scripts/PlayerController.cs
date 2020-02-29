using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb2d;
    private static Rigidbody2D rigidbd2D;
    private SpriteRenderer spriteRenderer;

    public float moveSpeed = 4f;
    public float jumpForce = 10f;

    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        rigidbd2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
}

    // Update is called once per frame
    void Update()
    {
        movement();
        jump();
    }

    void movement()
    {
        //Movement
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //make player move right
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);

            //flip player to the right
            spriteRenderer.flipX = false;

            //play the walking animation
            animator.SetBool("Moving", true);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //make player move left
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);

            //flip player to left
            spriteRenderer.flipX = true;

            if (isGrounded == true)
            {
                //play the walking animation
                animator.SetBool("Moving", true);
            }

            if (isGrounded == false)
            {
                //play the walking animation
                animator.SetBool("Moving", false);
            }
        }
        else
        {
            //play the walking animation
            animator.SetBool("Moving", false);

            //make player stop immediately after releasing key
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }

    void jump()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && isGrounded == true)
        {
            //make the player jump
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

            //play the jump animation
            animator.SetBool("Jump", true);
        }
        else
        {
            //if the player is not jump stop the jump animation
            animator.SetBool("Jump", false);
        }
    }

    public static void freezePlayer()
    {
        rigidbd2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
