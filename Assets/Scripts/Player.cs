using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject BrickInstance;
    InputAction throwAction;

    private void Start()
    {
        throwAction = InputSystem.actions.FindAction("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        if(throwAction.WasPressedThisFrame())
        {
            animator.SetTrigger("throw");
        }
    }

    public void Throw()
    {
        GameObject Brick = Instantiate(BrickInstance);
        Rigidbody2D rb = Brick.GetComponent<Rigidbody2D>();
        Vector2 throwDirection = (Vector2.up + Vector2.right).normalized;
        float throwStrength = 500.0f;
        rb.AddForce(throwDirection * throwStrength);
        rb.angularVelocity = -300.0f;
    }


}
