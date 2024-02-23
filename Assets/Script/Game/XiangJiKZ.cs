using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XiangJiKZ : MonoBehaviour
{
    public Transform car;
    Vector3 Offset;
    float distance;//����

    float rotateSpeed = 1f;//��ת�ٶ�
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
    void ZoomView() //�����ӽ�
    {
        distance = Offset.magnitude;//����<��С>
        distance += Input.GetAxis("Mouse ScrollWheel") *3f;//���ƹ���
        distance = Mathf.Clamp(distance,1,10);
        Offset = distance * Offset.normalized;//����ת��Ϊ������  ���¸�ƫ��ֵ��ֵ��    
    }
    void RotateCamera() //��ת�ӽǺ������ӽ�
    {
         
        if (Input.GetMouseButton(0))            
        {
            //Χ��������ת���������壬������ᣬ�ٶ�ֵ��
            transform.RotateAround(car.position, car.up, Input.GetAxis("Mouse X")* rotateSpeed);
            
            Vector3 tempPos = transform.position;//��ʱλ��
            Quaternion tempRot = transform.rotation;//��ʱ�Ƕ�
            //Χ��������ת���������壬�����X�ᣬ�ٶ�ֵ��,������ת
            transform.RotateAround(car.position, transform.right, Input.GetAxis("Mouse Y")*rotateSpeed );
            
            float value = transform.eulerAngles.x;//�����Xֵ��ŷ���ǣ�
            if (value>30) 
            {
                transform.position = tempPos;
                transform.rotation = tempRot;
            }    
        }
        
        // �����Ѿ��ı��������ˮƽλ�ã�����Ҫ����һ��λ��
        Offset = transform.position - car.position;
    }
}
