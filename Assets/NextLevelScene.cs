using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScene : MonoBehaviour
{
    public void LoadSceneByIndex()
    {
        SceneManager.LoadScene(1);
    }
}
