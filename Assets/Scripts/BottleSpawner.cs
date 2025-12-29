using UnityEngine;

public class BottleSpawner : MonoBehaviour
{
    float spawnTime = 4.0f;
    float timer = 0.0f;
    [SerializeField] GameObject[] bottles;
    int index = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            GameObject bottle = Instantiate(bottles[index++ % bottles.Length], transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            GameObject bottle = Instantiate(bottles[index++ % bottles.Length], transform.position, Quaternion.identity);
            timer = 0.0f;
        }
    }
}
