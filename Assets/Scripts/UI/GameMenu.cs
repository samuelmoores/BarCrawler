using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
