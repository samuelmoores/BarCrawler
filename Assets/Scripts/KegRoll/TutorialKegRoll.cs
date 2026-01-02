using TMPro;
using UnityEngine;

public class TutorialKegRoll : MonoBehaviour
{
    [SerializeField] PlayerKegRoller player;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] int numTutorialChecks;
    [SerializeField] float tutorialTime;
    int[] checks;
    float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        checks = player.RunTutorial();

        for(int i = 0; i < 2; i++)
        {
            if (checks[0] > numTutorialChecks && checks[1] > numTutorialChecks && timer > tutorialTime)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
