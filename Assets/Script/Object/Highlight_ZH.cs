using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class Highlight_ZH : MonoBehaviour
{
    public GameObject _HighlightableObject;
    public bool ishigh;
    void Awake()
    {
        //初始化组件


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            ishigh = true;
            _HighlightableObject.GetComponent<Outline>().enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ishigh = true;
            _HighlightableObject.GetComponent<Outline>().enabled = true;
        }

    }
}