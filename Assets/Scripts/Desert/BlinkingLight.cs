using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    [SerializeField] float blinkTime;
    float timer = 0.0f;
    bool toggle = true;

    SpriteRenderer sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > blinkTime)
        {
            toggle = !toggle;
            sprite.enabled = toggle;
            timer = 0.0f;
        }
    }
}
