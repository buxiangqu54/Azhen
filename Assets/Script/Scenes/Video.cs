using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName;

    private bool isVideoEnd = false;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void Update()
    {
        if (isVideoEnd)
        {
            Application.Quit();
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        isVideoEnd = true;
    }
}