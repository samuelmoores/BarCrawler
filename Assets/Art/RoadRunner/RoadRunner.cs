using UnityEngine;

public class RoadRunner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * 4.0f);

        if (transform.position.x < -11.0f)
        {
            Vector3 newPos = transform.position;
            newPos.x = 10.0f;
            transform.position = newPos;

        }
    }
}
