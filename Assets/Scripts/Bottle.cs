using UnityEngine;

public class Bottle : MonoBehaviour
{
    float moveSpeed = 7.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);

        if (transform.localPosition.x < -2.79f)
            Destroy(gameObject);
    }

    public void IncreaseSpeed()
    {
        moveSpeed++;
    }
}
