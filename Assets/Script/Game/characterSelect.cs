using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class characterSelect : MonoBehaviour
{
    public GameObject[] characterPrefabs;//创建一个人物预制体数组，存储人物角色
    private int selectedIndex = 0;//创建选择索引的变量
    private int length=3;

    // Use this for initialization
    void Start()
    {
        //调用显示人物角色的方法
        CharacterShow();
    }
    //查找并显示对应的人物角色 
    void CharacterShow()
    {
        characterPrefabs[selectedIndex].SetActive(true);//显示对应索引的人物预制体
        //通过循环隐藏不对应索引的预制体
        for (int i = 0; i < length; i++)
        {
            if (i != selectedIndex)
            {
                characterPrefabs[i].SetActive(false);//把未选择的角色设置为隐藏
            }
        }
    }
    //当我们点击了下一个按钮
    public void OnNextButtonClick()
    {
        selectedIndex++;
        selectedIndex %= length;
        CharacterShow();
    }
    //当我们点击了上一个按钮
    public void OnPrevButtonClick()
    {
        selectedIndex--;
        if (selectedIndex == -1)
        {
            selectedIndex = length - 1;
        }
        CharacterShow();
    }
}
