using UnityEngine;
using UnityEngine.Rendering;

public class Vulture : MonoBehaviour
{
    [SerializeField] float startTimer = 3.0f;
    [SerializeField] Transform[] flyPoints;
    Transform currentFlyPoint;
    int flyPointIndex = 0;
    float changeFlyPointCooldown = 0.25f;

    float timer = 0.0f;
    float jumpDuration = 0.5f;
    bool flying = false;

    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > startTimer && !flying)
        {
            animator.SetTrigger("jump");
            flying = true;
            timer = 0.0f;
        }

        if(flying)
        {
            if(timer > jumpDuration)
                animator.SetBool("fly", true);

            float distance = Vector3.Distance(flyPoints[flyPointIndex].position, transform.position);

            Vector3 flyDirection = (flyPoints[flyPointIndex].position - transform.position).normalized;

            if (distance < 0.01f)
            {
                flyPointIndex = (++flyPointIndex) % flyPoints.Length;
                if (flyDirection.x == 1.0f || flyDirection.x == -1.0f)
                    transform.localScale = new Vector3(-transform.localScale.x, 1.0f, 1.0f);
            }


            transform.Translate(flyDirection * Time.deltaTime);
        }

    }
}
