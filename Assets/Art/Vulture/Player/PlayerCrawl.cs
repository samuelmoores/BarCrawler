using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCrawl : MonoBehaviour
{
    [SerializeField] float crawlSpeed;

    [SerializeField] Sprite turdCover;
    [SerializeField] Sprite normalPlayerClean;

    InputAction crawl;
    Animator animator;

    bool canMove = true;
    float freezeTimer = 5.0f;
    float timer = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        crawl = InputSystem.actions.FindAction("move");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            float xinput = crawl.ReadValue<Vector2>().normalized.x;
            Vector2 direction = Vector2.zero;
            direction.x = xinput;
            animator.SetBool("crawl", xinput != 0.0f);

            transform.Translate(direction * crawlSpeed * Time.deltaTime);
        }
        else
        {
            timer += Time.deltaTime;

            if(timer > freezeTimer)
            {
                canMove = true;
                timer = 0.0f;
                animator.SetBool("turd", false);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        animator.SetBool("turd", true);
        canMove = false;
    }
}
