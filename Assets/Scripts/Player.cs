using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject BrickInstance;
    InputAction throwAction;
    Vector2 mousePosition;
    float throwStengthModifier = 8.0f;
    float attackCooldown = 2.0f;
    float attackCooldownTimer;

    private void Start()
    {
        throwAction = InputSystem.actions.FindAction("Attack");
        mousePosition.x = 0.0f;
        attackCooldownTimer = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCooldownTimer > 0.0f)
            attackCooldownTimer -= Time.deltaTime;

        if (throwAction.WasPressedThisFrame() && attackCooldownTimer < 0.0f)
        {
            attackCooldownTimer = attackCooldown;
            mousePosition = Mouse.current.position.ReadValue().normalized;
            if(Mouse.current.position.ReadValue().x / 100.0f > 8.0f)
                throwStengthModifier = Mouse.current.position.ReadValue().x / 100.0f;
            mousePosition.x = 0.0f;
            animator.SetTrigger("throw");
        }
    }

    public void Throw()
    {
        GameObject Brick = Instantiate(BrickInstance);
        Destroy(Brick, 10.0f);
        Rigidbody2D rb = Brick.GetComponent<Rigidbody2D>();
        float throwStrength = 50.0f * throwStengthModifier;
        Vector2 throwDirection = (Vector2.up + Vector2.right/2 + mousePosition).normalized;
        rb.AddForce(throwDirection * throwStrength);
        rb.angularVelocity = -300.0f;
        throwStengthModifier = 8.0f;
    }


}
