using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDesertCactus : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject cactusInstance;
    [SerializeField] CircleCollider2D punchBox;
    InputAction punch;
    GameObject cactus;
    float flatTimer = 4.0f;
    float timer = 0.0f;
    float punchCoolDown = 1.00f;
    float coolDownTimer = 0.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        punch = InputSystem.actions.FindAction("Attack");

    }

    // Update is called once per frame
    void Update()
    {
        coolDownTimer -= Time.deltaTime;

        if (punch.WasPressedThisFrame() && coolDownTimer <= 0.0f && timer <= 0.0f)
        {
            animator.SetTrigger("punch");
            coolDownTimer = punchCoolDown;
        }
        
        if(timer > 0.0f)
        {
            timer -= Time.deltaTime;

            if (timer <= 0.0f)
                animator.SetBool("flat", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Cactus"))
        {
            if (coolDownTimer < 0.95f)
            {
                animator.SetBool("flat", true);
                timer = flatTimer;
            }
            else
            {
                cactus = collision.gameObject;
                cactus.GetComponent<Cactus>().Die();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Cactus"))
        {
            cactus = null;
        }

    }
}
