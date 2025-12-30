using UnityEngine;

public class KegSpawner : MonoBehaviour
{
    [SerializeField] GameObject kegInstance;
    [SerializeField] float spawnInterval;
    float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0.0f)
        {
            GameObject keg = Instantiate(kegInstance);
            Destroy(keg, 4.0f);
            keg.GetComponent<Keg>().Launch();
            timer = spawnInterval;
        }
    }
}
