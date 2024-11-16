using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentMusic1 : MonoBehaviour
{
    private static PersistentMusic1 instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep the music playing across scenes
            GetComponent<AudioSource>().Play(); // Start the music

            // Subscribe to the scene loaded event
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate music objects in other scenes
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from the scene loaded event to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void StopMusic()
    {
        GetComponent<AudioSource>().Stop();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the current scene is one where music should stop
        if (scene.name == "Game_Over" || scene.name == "Win_Scene" || scene.name == "The_Room" || scene.name == "Game_ui")
        {
            StopMusic();
        }
    }
}
