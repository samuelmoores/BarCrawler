using UnityEngine;

public class Waiter : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool goingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(goingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            if (transform.position.x > 11.2)
            {
                goingRight = false;
                transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            if(transform.position.x < -11.14)
            {
                goingRight = true;
                transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
            }
        }
    }
}
