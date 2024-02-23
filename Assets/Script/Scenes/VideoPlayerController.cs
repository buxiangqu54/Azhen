using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
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
            SceneManager.LoadScene(nextSceneName);
        }
    }
    public void sce()
    {
        SceneManager.LoadScene(nextSceneName);
    }
    void OnVideoEnd(VideoPlayer vp)
    {
        isVideoEnd = true;
    }
}