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
            //speed up bottle
            Bottle bottle = collision.gameObject.GetComponent<Bottle>();
            bottle.IncreaseSpeed();
            Destroy(collision.gameObject);

            //spawn explosion
            GameObject explosion = Instantiate(explosionInstance, transform.position, Quaternion.identity);
            Destroy(explosion, 0.1f);

            //reverse brick spin
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.angularVelocity = 250.0f;

            //increase score
            Debug.Log("GameManager singleton: " + GameManager.instance);
            GameManager.instance.IncreaseScore();
        }
    }
}
