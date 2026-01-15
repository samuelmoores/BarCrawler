using UnityEngine;
using UnityEngine.UIElements;

public class Cactus : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] CactusSpawner cactusSpawner;
    SpriteRenderer spriteRend;
    GameObject player;
    bool dead = false;
    float timer = -1;
    float moveSpeed = 4.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }

        if(dead)
        {
            Destroy(gameObject, 3.2f);
        }

        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;

            if (timer < 2.0f)
            {
                spriteRend = GameObject.Find("Cactus").GetComponent<SpriteRenderer>();
                spriteRend.enabled = false;
            }

        }
    }

    public void Die()
    {
        timer = 3.0f;
        dead = true;
        animator.SetBool("dead", true);
        GetComponent<CircleCollider2D>().enabled = false;
    }
}
