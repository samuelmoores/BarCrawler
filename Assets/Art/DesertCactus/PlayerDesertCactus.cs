using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDesertCactus : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject cactusInstance;
    InputAction punch;
    bool hitCactus = false;
    GameObject cactus;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        punch = InputSystem.actions.FindAction("Attack");

    }

    // Update is called once per frame
    void Update()
    {
        if (punch.WasPressedThisFrame())
        {
            animator.SetTrigger("punch");
            if (hitCactus)
            {
                cactus.GetComponent<Cactus>().Die();
                hitCactus = false;
            }

        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Cactus"))
        {
            Debug.Log("Triggered Cactus");
            cactus = collision.gameObject;
            hitCactus = true;
        }
    }
}
