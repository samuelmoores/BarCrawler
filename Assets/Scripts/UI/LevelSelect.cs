using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void LoadLevel(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
