using UnityEngine;
using UnityEngine.InputSystem;

public class MoonPlayer : MonoBehaviour
{
    [SerializeField] float crawlSpeed;
    [SerializeField] AnimationClip damageAnimClip;
    [SerializeField] AnimationClip attackAnimClip;

    InputAction crawl;
    InputAction attack;
    Animator animator;

    float freezeTimer = 0.0f;
    bool attacking = false;
    float attackCooldown = 1.0f;
    float attackCooldownTime = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        crawl = InputSystem.actions.FindAction("move");
        attack = InputSystem.actions.FindAction("attack");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        freezeTimer -= Time.deltaTime;
        attackCooldown -= Time.deltaTime;

        if(freezeTimer <= 0.0f)
        {
            attacking = false;
            float xinput = crawl.ReadValue<Vector2>().normalized.x;
            Vector2 direction = Vector2.zero;
            direction.x = xinput;
            animator.SetBool("crawl", xinput != 0.0f);
            transform.Translate(direction * crawlSpeed * Time.deltaTime);

            if(attack.WasPressedThisFrame() && attackCooldown < 0.0f)
            {
                animator.SetTrigger("attack");
                freezeTimer = attackAnimClip.length;
                attacking = true;
                attackCooldown = attackCooldownTime;
            }
        }

    }

    public bool Attack()
    {
        return attacking;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!attacking)
        {
            Debug.Log("take damage");
            freezeTimer = damageAnimClip.length;
            animator.SetTrigger("damage");
        }
        else
        {
            Moon moon = collision.gameObject.GetComponent<Moon>();
            Debug.Log(moon);

            if(moon)
            {
                moon.TakeDamage();
            }
        }

    }
}
