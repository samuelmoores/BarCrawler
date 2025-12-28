using UnityEngine;
using UnityEngine.UIElements;

public class Bottle : MonoBehaviour
{
    float startY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime);

        Debug.Log(transform.localPosition.x);

        if (transform.localPosition.x < -15.79f)
            transform.localPosition = new Vector2(2.0f, startY);
    }
}
