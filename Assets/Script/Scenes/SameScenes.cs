using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameScenes : MonoBehaviour
{
    public Transform target;
    public Transform par;
    public GameObject ftips;
    private bool ismove;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ismove = true;
            ftips.SetActive(true);


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ismove = false;
            ftips.SetActive(false);
        }
    }
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ismove&&Input.GetKey(KeyCode.F))
        {
            par.transform.position = target.transform.position;
            ftips.SetActive(false);
        }
        
    }
}
