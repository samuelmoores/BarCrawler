using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;
using static UnityEngine.GraphicsBuffer;

public class PlayerDesert : MonoBehaviour
{
    [SerializeField] Transform crawlTarget;
    [SerializeField] float crawlSpeed;
    [SerializeField] Vector2 endScale;
    InputAction crawl;
    Vector2 startPosition;
    Vector2 moveDirection;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        crawl = InputSystem.actions.FindAction("move");
        startPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //am i at a min or max?
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, startPosition.x, crawlTarget.position.x), Mathf.Clamp(transform.position.y, startPosition.y, crawlTarget.position.y), 0.0f);
        float xinput = crawl.ReadValue<Vector2>().normalized.x;
        Vector2 direction = Vector2.zero;
        Vector2 positon2D = transform.position;
        Vector2 scale = transform.localScale;
        
        animator.SetBool("crawl", xinput != 0.0f);

        if (xinput > 0.0f)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, endScale, Time.deltaTime * 0.2f);
            direction = (crawlTarget.position - transform.position).normalized;
        }

        if(xinput < 0.0f)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, Vector2.one, Time.deltaTime * 0.2f);
            direction = (startPosition - positon2D).normalized;
        }

        transform.Translate(direction * crawlSpeed * Time.deltaTime);
    }
}
