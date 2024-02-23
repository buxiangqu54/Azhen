using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public GameObject UI;
    public GameObject gob;
    public GameObject obj;
    public GameObject me;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseDown()
    {
        UI.SetActive(true);
        gob.SetActive(true);
        obj.GetComponent<FollowPlayer>().enabled = false;
    }
    public void Guanbi()
    {
        UI.SetActive(false);
        gob.SetActive(false);
        obj.GetComponent<FollowPlayer>().enabled = true;


    }
    private void OnMouseEnter()
    {
        me.GetComponent<Outline>().enabled = true;
    }
    private void OnMouseExit()
    {
        me.GetComponent<Outline>().enabled = false;
    }
}
