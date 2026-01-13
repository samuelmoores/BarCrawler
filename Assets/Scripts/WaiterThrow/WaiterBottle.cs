using UnityEngine;

public class WaiterBottle : MonoBehaviour
{
    [SerializeField] GameObject explosionInstance;
    bool hit = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        if(hit)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            hit = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Brick"))
        {
            GameObject explosion = Instantiate(explosionInstance, transform.position, Quaternion.identity);
            explosion.GetComponent<SpriteRenderer>().sortingOrder = gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
            Debug.Log(explosion.transform.position);
            Destroy(explosion, 0.15f);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            hit = true;
        }
    }
}
