using UnityEngine;
using UnityEngine.EventSystems;

public class Moon : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip biteAnimClip;
    [SerializeField] float moveSpeed;
    [SerializeField] float attackReadyTime;
    [SerializeField] float stoppingDistance;
    float distanceFromPlayer;
    Vector3 moveDirection;
    Vector3 startPosition;

    float attackReadyTimer;
    bool attack = false;

    float shakeTime = 3.0f;
    float shakeTimer = 0.0f;

    bool bite = false;
    bool returnToStart = false;

    float biteTime;
    float biteTimer = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator.GetComponent<Animator>();
        startPosition = transform.position;
        biteTime = biteAnimClip.length;
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Vector3.Distance(player.transform.position, transform.position);

        //timer to start shacking
        if(attackReadyTimer < attackReadyTime)
        {
            attackReadyTimer += Time.deltaTime;

            if(attackReadyTimer >= attackReadyTime)
            {
                animator.SetBool("mouth", true);
                shakeTimer = shakeTime;
            }
        }

        //time to stop shacking
        if(shakeTimer > 0.0f)
        {
            Debug.Log("shake: " + shakeTimer);
            shakeTimer -= Time.deltaTime;

            if (shakeTimer <= 0.01f)
                attack = true;
        }

        //dash toward player
        if(attack && distanceFromPlayer > stoppingDistance)
        {
            moveDirection = (player.transform.position - transform.position).normalized;
            Debug.Log("desh to player: " + moveDirection);
            transform.Translate(moveDirection * Time.deltaTime * moveSpeed);
            distanceFromPlayer = Vector3.Distance(player.transform.position, transform.position);

            if (distanceFromPlayer <= stoppingDistance)
                bite = true;
        }

        //start bite
        if(bite)
        {
            animator.SetTrigger("bite");
            animator.SetBool("mouth", false);
            bite = false;
            biteTimer = biteTime;
        }

        //play bite animation
        if(biteTimer > 0.0f)
        {
            biteTimer -= Time.deltaTime;


            if (biteTimer <= 0.0f)
            {
                returnToStart = true;
                attack = false;
            }
        }

        //go back to start
        if(returnToStart)
        {
            moveDirection = (startPosition - transform.position).normalized;

            if(Vector3.Distance(startPosition, transform.position) > 0.01f)
            {
                Debug.Log("moving back to start: " + moveDirection);
                transform.Translate(moveDirection * Time.deltaTime * moveSpeed);
            }
            else
            {
                returnToStart = false;
            }
        }
    }
}
