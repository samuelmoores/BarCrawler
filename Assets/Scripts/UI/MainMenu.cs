using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int firstLevel;
    public void PlayGame()
    {
        SceneManager.LoadScene(firstLevel);
    }
}
