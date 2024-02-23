using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class characterSelect : MonoBehaviour
{
    public GameObject[] characterPrefabs;//����һ������Ԥ�������飬�洢�����ɫ
    private int selectedIndex = 0;//����ѡ�������ı���
    private int length=3;

    // Use this for initialization
    void Start()
    {
        //������ʾ�����ɫ�ķ���
        CharacterShow();
    }
    //���Ҳ���ʾ��Ӧ�������ɫ 
    void CharacterShow()
    {
        characterPrefabs[selectedIndex].SetActive(true);//��ʾ��Ӧ����������Ԥ����
        //ͨ��ѭ�����ز���Ӧ������Ԥ����
        for (int i = 0; i < length; i++)
        {
            if (i != selectedIndex)
            {
                characterPrefabs[i].SetActive(false);//��δѡ��Ľ�ɫ����Ϊ����
            }
        }
    }
    //�����ǵ������һ����ť
    public void OnNextButtonClick()
    {
        selectedIndex++;
        selectedIndex %= length;
        CharacterShow();
    }
    //�����ǵ������һ����ť
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
