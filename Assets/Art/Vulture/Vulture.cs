using UnityEngine;
using UnityEngine.Rendering;

public class Vulture : MonoBehaviour
{
    [SerializeField] float flySpeed;
    [SerializeField] float startTimer = 3.0f;
    [SerializeField] Transform[] flyPoints;
    TurdSpawner turdSpawner;
    float deficationInterval = 2.0f;
    float deficationTimer = 0.0f;
    int flyPointIndex = 0;
    Vector3 flyDirection;

    float timer = 0.0f;
    float jumpDuration = 0.5f;
    bool flying = false;
    bool goingLeft = false;
    float distance;
    int frame = 0;

    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        turdSpawner = GetComponent<TurdSpawner>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        deficationTimer += Time.deltaTime;
        frame++;

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

            distance = Vector3.Distance(flyPoints[flyPointIndex].position, transform.position);

            flyDirection = (flyPoints[flyPointIndex].position - transform.position).normalized;

            if ( distance <= 0.5f)
            {
                flyPointIndex = (++flyPointIndex) % flyPoints.Length;

                if (goingLeft)
                {
                    transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                    goingLeft = false;
                }
                else
                {
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    goingLeft = true;
                }

            }

            if(deficationTimer > deficationInterval)
            {
                turdSpawner.SpawnTurn();
                deficationTimer = 0.0f;
            }

            transform.Translate(flyDirection * Time.deltaTime * flySpeed);
        }

    }
}
