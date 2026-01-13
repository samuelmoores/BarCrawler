using UnityEngine;

public class CactusSpawner : MonoBehaviour
{
    [SerializeField] GameObject cactusInstance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        GameObject newCactus = Instantiate(cactusInstance);
    }
}
