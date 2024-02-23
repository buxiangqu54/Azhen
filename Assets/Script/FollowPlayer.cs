using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    private Transform player;
    private Vector3 offsetPosition; //λ��ƫ��
    private bool isRotate;

    public float distance;
    public float scrollSpeed = 10;
    public float RotateSpeed = 2;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(player.position);
        offsetPosition = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offsetPosition + player.position;

        //RotateView();

        //ScrollView();
    }

    void ScrollView()
    {
        //��껬��������Զ��Ұ
        distance = offsetPosition.magnitude;
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        distance = Mathf.Clamp(distance, 2, 18);//���ƾ�ͷ������Զ�Լ��������
        offsetPosition = offsetPosition.normalized * distance;
    }

    void RotateView()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRotate = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRotate = false;
        }

        if (isRotate)
        {
            transform.RotateAround(player.position, player.up, RotateSpeed * Input.GetAxis("Mouse X"));

            Vector3 originalPos = transform.position;
            Quaternion originalRotation = transform.rotation;

            transform.RotateAround(player.position, transform.right, -RotateSpeed * Input.GetAxis("Mouse Y"));
            //��ֱ��ˮƽ����Ӱ������ֵ

            float x = transform.eulerAngles.x;

            if (x < 10 || x > 80)
            {
                transform.position = originalPos;
                transform.rotation = originalRotation;
            }
        }
        offsetPosition = transform.position - player.position;
    }
}

