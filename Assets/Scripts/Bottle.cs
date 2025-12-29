using UnityEngine;

public class Bottle : MonoBehaviour
{
    float moveSpeed;

    private void Start()
    {
        moveSpeed = GameManager.instance.GetBottleMoveSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);

        if (transform.localPosition.x < -3.940958f)
            Destroy(gameObject);
    }

}
