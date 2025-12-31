using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerKegRoller : MonoBehaviour
{
    [SerializeField] float jumpStrength;
    [SerializeField] float flattenTimer = 3.0f;
    Animator animator;
    Rigidbody2D rb;
    InputAction jump;
    InputAction move;
    float timer;
    bool onGround = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        jump = InputSystem.actions.FindAction("Attack");
        move = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (jump.WasPressedThisFrame() && CanJump())
        {
            animator.SetBool("jump", true);
            onGround = false;
            rb.AddForce(Vector2.up * jumpStrength);
        }

        if(move.IsPressed())
        {
            Debug.Log("move is pressed");
        }
    }

    bool CanJump()
    {
        return onGround && timer <= 0.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("on ground");
            animator.SetBool("jump", false);
            onGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Keg"))
        {
            animator.SetTrigger("flat");
            timer = flattenTimer;
        }
    }
}
