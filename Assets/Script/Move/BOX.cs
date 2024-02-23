using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX : MonoBehaviour
{
  
    GameObject temp;
    public bool CanMoveToDir(Vector3 direct)
    {

        RaycastHit hit;
        //1.判断移动方向前一格是否有碰撞体
        if (Physics.Raycast(transform.position, direct, out hit, 0.35f))
        {
            Debug.Log("y-" + hit.transform.name);
            if (hit.transform.tag == "wall")
            {
                return true;
            }
            if (hit.transform.tag == "xiangzi")
            {
                return true;
            }
           
        }
        return false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "xiangzi")
        {
            
            temp = collision.gameObject;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "xiangzi")
        {
            
        }
    }
}
