using UnityEngine;

public class TurdSpawner : MonoBehaviour
{
    [SerializeField] GameObject turdInstance;
    
    public void SpawnTurn()
    {
        GameObject turd = Instantiate(turdInstance, transform.position, Quaternion.identity);
        Destroy(turd, 8.0f);
    }
}
