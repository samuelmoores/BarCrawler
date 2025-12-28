using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] GameObject explosionInstance;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bottle"))
        {
            Destroy(collision.gameObject);
            GameObject explosion = Instantiate(explosionInstance, transform.position, Quaternion.identity);
            Destroy(explosion, 0.1f);
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.angularVelocity = 250.0f;
        }
    }
}
