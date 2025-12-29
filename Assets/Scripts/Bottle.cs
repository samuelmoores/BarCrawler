using UnityEngine;

public class Bottle : MonoBehaviour
{
    float moveSpeed = 7.0f;

    private void Start()
    {
        Debug.Log("bottle spawned with speed: " + GameManager.instance.GetBottleMoveSpeed());
        moveSpeed = GameManager.instance.GetBottleMoveSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);

        if (transform.localPosition.x < -2.79f)
            Destroy(gameObject);
    }

}
