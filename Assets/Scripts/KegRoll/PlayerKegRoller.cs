using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerKegRoller : MonoBehaviour
{
    [SerializeField] float jumpHeight;
    [SerializeField] float flattenTime = 3.0f;
    [SerializeField] float crawlSpeed = 1.0f;
    Animator animator;
    Rigidbody2D rb;
    InputAction jump;
    InputAction move;
    float flattenTimer;
    bool onGround = true;
    int[] tutorialCheck;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        jump = new InputAction("Tits", binding: "<Keyboard>/upArrow");
        jump.Enable();
        move = InputSystem.actions.FindAction("Move");
        tutorialCheck = new int[2];
    }

    // Update is called once per frame
    void Update()
    {
        flattenTimer -= Time.deltaTime;

        // Horizontal movement
        float moveInput = move.ReadValue<Vector2>().x;

        if (!onGround)
            moveInput /= 3.0f;

        rb.linearVelocity = new Vector2(moveInput * crawlSpeed, rb.linearVelocity.y);

        // Jump
        if (jump.WasPressedThisFrame() && onGround && flattenTimer < 0.0f)
        {
            animator.SetBool("jump", true);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
            onGround = false;
            tutorialCheck[0]++;
        }

        if(move.WasPressedThisFrame() && move.ReadValue<Vector2>().x != 0.0f && flattenTimer < 0.0f)
        {
            tutorialCheck[1]++;
        }

        if (flattenTimer > 0.0f)
            rb.linearVelocity = Vector2.down * 10.0f;

    }

    public int[] RunTutorial()
    {
        return tutorialCheck;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("jump", false);
            onGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");

        if(collision.gameObject.CompareTag("Keg"))
        {
            animator.SetTrigger("flat");
            flattenTimer = flattenTime;
        }
    }
}
