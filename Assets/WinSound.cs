using UnityEngine;

public class WinSound : MonoBehaviour
{
    private static WinSound instance=null;

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    public void StopMusic()
    {
        GetComponent<AudioSource>().Stop();
    }
}
