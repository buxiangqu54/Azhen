using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XiangJiKZ : MonoBehaviour
{
    public Transform car;
    Vector3 Offset;
    float distance;//距离

    float rotateSpeed = 1f;//旋转速度
    void Start()
    {
        Offset =  transform.position-car.position;
    }

   
    void Update()
    {
         transform.position = Offset + car.position;
        //transform.position = Vector3.Lerp(transform.position, Offset + car.position, 0.5f*Time.deltaTime);
        RotateCamera();
        ZoomView();
       
    }
    void ZoomView() //缩放视角
    {
        distance = Offset.magnitude;//标量<大小>
        distance += Input.GetAxis("Mouse ScrollWheel") *3f;//控制滚轮
        distance = Mathf.Clamp(distance,1,10);
        Offset = distance * Offset.normalized;//标量转化为向量，  从新给偏量值赋值，    
    }
    void RotateCamera() //旋转视角和上下视角
    {
         
        if (Input.GetMouseButton(0))            
        {
            //围绕物体旋转（看向物体，物体的轴，速度值）
            transform.RotateAround(car.position, car.up, Input.GetAxis("Mouse X")* rotateSpeed);
            
            Vector3 tempPos = transform.position;//临时位置
            Quaternion tempRot = transform.rotation;//临时角度
            //围绕物体旋转（看向物体，自身的X轴，速度值）,上下旋转
            transform.RotateAround(car.position, transform.right, Input.GetAxis("Mouse Y")*rotateSpeed );
            
            float value = transform.eulerAngles.x;//相机的X值（欧拉角）
            if (value>30) 
            {
                transform.position = tempPos;
                transform.rotation = tempRot;
            }    
        }
        
        // 上面已经改变了相机的水平位置，所以要更新一下位置
        Offset = transform.position - car.position;
    }
}
