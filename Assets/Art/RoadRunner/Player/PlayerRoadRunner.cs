using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRoadRunner : MonoBehaviour
{
    [SerializeField] float crawlSpeed;
    [SerializeField] float jumpForce;

    [SerializeField] GameObject BG_01;
    [SerializeField] GameObject BG_02;
    [SerializeField] GameObject BG_03;
    [SerializeField] AnimationClip flatAnim;

    InputAction crawl;
    InputAction jump;
    Animator animator;
    Rigidbody2D rb;

    float timer = 0.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        crawl = InputSystem.actions.FindAction("move");
        jump = InputSystem.actions.FindAction("jump");
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        float xinput = crawl.ReadValue<Vector2>().normalized.x;
        Vector3 direction = Vector3.zero;
        direction.x = xinput;

        if ((transform.position.x > -8.64f || direction.x > 0.0f) && timer < 0.0f)
        {
            animator.SetBool("crawl", direction.magnitude > 0.0f);
            transform.Translate(direction * crawlSpeed * Time.deltaTime);
            BG_01.transform.Translate(direction * -crawlSpeed / 4 * Time.deltaTime);
            BG_02.transform.Translate(direction * -crawlSpeed / 8 * Time.deltaTime);
            BG_03.transform.Translate(direction * -crawlSpeed / 16 * Time.deltaTime);
        }
        else
        {
            animator.SetBool("crawl", false);
        }

        if (jump.WasPressedThisFrame())
        {
            rb.AddForce(Vector3.up * jumpForce);
            animator.SetBool("inAir", true);
        }

        Debug.Log(rb.linearVelocityY);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        timer = flatAnim.length;
        animator.SetTrigger("flat");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("inAir", false);
    }
}
