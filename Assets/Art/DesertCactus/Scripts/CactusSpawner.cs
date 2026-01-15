using UnityEngine;

public class CactusSpawner : MonoBehaviour
{
    [SerializeField] GameObject cactusInstance;
    [SerializeField] float spawnTimer = 10.0f;
    float timer = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = spawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0.0f)
        {
            Spawn();
            timer = spawnTimer;
        }
    }

    public void Spawn()
    {
        GameObject newCactus = Instantiate(cactusInstance);
    }
}
