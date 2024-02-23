using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class askandanswer : MonoBehaviour
{
    public Image question; //问题图片
    public Image answer; //恭喜答对图片
    public Button correct;
    public Button correct1;//正确选项的按钮
    public Button wrong; //错误选项的按钮
    public Button wrong1;
    public Button wrong2;
    void Start()
    {
        question.gameObject.SetActive(true); //初始时显示问题图片
        answer.gameObject.SetActive(false); //初始时隐藏恭喜答对图片
    }

    public void OnCorrectClick() //点击正确选项时
    {
        question.gameObject.SetActive(false); //隐藏问题图片
        answer.gameObject.SetActive(true); //显示恭喜答对图片
    }

    public void OnWrongClick() //点击错误选项时
    {
        //你可以在这里添加一些反馈或提示，比如播放音效或显示文字
    }
}