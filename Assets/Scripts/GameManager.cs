using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;
    float bottleMoveSpeed = 7.0f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public float GetBottleMoveSpeed()
    {
        return bottleMoveSpeed;
    }

    public void IncreaseBottleMoveSpeed()
    {
        bottleMoveSpeed++;
    }
}
