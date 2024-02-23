using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoon : MonoBehaviour
{
    public Transform[] targets;
    Transform target;
    int index = 0;
    public float speed = 5f;
  public   float yy = -90;
    void Start()
    {
        target = targets[index];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (target.position - transform.position).normalized * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, target.position) <= 0.005f)
        {

            yy += 90;

            transform.rotation = Quaternion.Euler(0, yy, 0);

            target = targets[++index];

            if (index >= 3)
            {

                index = -1;
            }
        }
    }
}
