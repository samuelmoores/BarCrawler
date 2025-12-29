using UnityEngine;

public class BottleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] bottles;
    [SerializeField] float spawnTime = 0.25f;
    float timer = 0.0f;
    float timeBetweenRounds = 3.0f;

    //bookends
    int bookendIndex = 0;
    int numBookendsTotal = 4;
    int numBookendsCurr = 0;

    //target
    int targetIndex = 2;
    bool spawnTarget = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = spawnTime + 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //spawn bookends
        if (timer > spawnTime && numBookendsCurr < numBookendsTotal)
        {
            GameObject bottle = Instantiate(bottles[bookendIndex], transform.position, Quaternion.identity);
            numBookendsCurr++;
            timer = 0.0f;

            //dont let brick bounce across all bottles to hit target, let it fall before it reaches target
            //which is about two bottle before
            if (numBookendsCurr > numBookendsTotal - 2)
                bottle.GetComponent<BoxCollider2D>().enabled = false;

            if (numBookendsCurr == numBookendsTotal && !spawnTarget)
            {
                spawnTarget = true;
            }
            else if(numBookendsCurr == numBookendsTotal && spawnTarget)
            {
                timer = -timeBetweenRounds;
                spawnTarget = false;
                numBookendsCurr = 0;

                bookendIndex = ++bookendIndex % bottles.Length;
                Debug.Log("new bookend index: " + bookendIndex);
                Debug.Log("timer: " + timer);
                if (bookendIndex == targetIndex)
                    bookendIndex++;
            }

        }
        else if(timer > spawnTime && spawnTarget)
        {
            GameObject bottle = Instantiate(bottles[targetIndex], transform.position, Quaternion.identity);
            numBookendsCurr = 0;
            timer = 0.0f;
        }
    }
}
