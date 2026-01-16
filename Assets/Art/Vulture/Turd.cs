using UnityEngine;

public class Turd : MonoBehaviour
{
    [SerializeField] Sprite[] turdSplats;
    SpriteRenderer spriteRend;
    int index = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRend.sprite = turdSplats[index++ % turdSplats.Length];
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0.0f;
    }
}
