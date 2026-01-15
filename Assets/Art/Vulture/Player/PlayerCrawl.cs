using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCrawl : MonoBehaviour
{
    [SerializeField] float crawlSpeed;

    InputAction crawl;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        crawl = InputSystem.actions.FindAction("move");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xinput = crawl.ReadValue<Vector2>().normalized.x;
        Vector2 direction = Vector2.zero;
        direction.x = xinput;
        animator.SetBool("crawl", xinput != 0.0f);

        transform.Translate(direction * crawlSpeed * Time.deltaTime);
    }
}
