using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public string sceneName;
    public GameObject shezhi;
    public GameObject wanfa;
    public void quitName()
    {
        Application.Quit();
    }
    public void scenes()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Stop()
    {
        Time.timeScale = 0;
    }
    public void Continue()
    {
        Time.timeScale = 1;
    }
    public void SheZhiOpen()
    {
        shezhi.SetActive(true);
    }
    public void shezhiClose()
    {
        shezhi.SetActive(false);
    }
    public void WanfaOpen()
    {
        wanfa.SetActive(true);
    }
    public void WanfaClose()
    {
        wanfa.SetActive(false);
    }
}
