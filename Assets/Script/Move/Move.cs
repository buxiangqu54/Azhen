using Fungus;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public GameObject Ftips;//������
    public GameObject Etips;
    private int IsDeath=2;//�Ƿ�����
    private bool IsGround=true;//�Ƿ��ڵ���
    private int State;//��ɫ״̬
    private int oldState = 0;//ǰһ�ν�ɫ��״̬
    private int UP = 0;//��ɫ״̬��ǰ
    private int RIGHT = 1;//��ɫ״̬����
    private int DOWN = 2;//��ɫ״̬���
    private int LEFT = 3;//��ɫ״̬����
    public Animator animator;
    public float speed = 1;
    private int speedID = Animator.StringToHash("Walk");
    //private int isSpeedID = Animator.StringToHash("IsSpeedUp");
    private int horizontalID = Animator.StringToHash("Turn");
    private float speedMax = 4.1f;
    private Rigidbody rb;
    public GameObject temp;
    public GameObject True_ui, False_ui, Win_ui,password1_ui, password2_ui;
    public int index;
    public Text thetext;
    Vector3 direct;
    public string sceneName;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        ToDeath();

        if (Input.GetKey("d"))
        {
            setState(UP);
            direct = new Vector3(0, 0, 1);
            
        }
        else if (Input.GetKey("a"))
        {
            setState(DOWN);
            direct = new Vector3(0, 0, -1);
           
        }

        else if (Input.GetKey("w"))
        {
            setState(LEFT); direct = new Vector3(-1, 0, 0);
           
        }
        else if (Input.GetKey("s"))
        {
            setState(RIGHT); direct = new Vector3(1, 0, 0);
           
        }
        ValidAndMoveBox();
        animator.SetFloat(speedID, Input.GetAxis("Vertical") * speedMax);
        animator.SetFloat(horizontalID, Input.GetAxis("Horizontal") * speedMax);
        PickUp();
        ToPassword();
        Jump();
        Talk();
        IsGrounded();
        
    }
  public  void ValidAndMoveBox()
    {
        if (Input.GetKeyDown(KeyCode.F)&& Ftips.activeInHierarchy)
        {
            if (temp.tag == "xiangzi"&&!canMove())
            {

                temp.transform.position += direct*1/2;
            }
        }
       
       
    }
    public bool canMove()
    {
        if (temp.GetComponent<BOX>() != null)
        {
            return temp.GetComponent<BOX>().CanMoveToDir(direct);
        }
        else { return true; }
    }

    void setState(int currState)
    {
        
        Vector3 transformValue = new Vector3();//����ƽ������
        int rotateValue = (currState - State) * 90;
        if (rotateValue == 0)
        {
            //animator.Play("walk");
            switch (currState)
            {
                case 0://��ɫ״̬��ǰʱ����ɫ������ǰ�����ƶ�
                    transformValue = Vector3.forward * Time.deltaTime * speed;
                    break;
                case 1://��ɫ״̬����ʱ����ɫ�������һ����ƶ�
                    transformValue = Vector3.right * Time.deltaTime * speed;

                    break;
                case 2://��ɫ״̬���ʱ����ɫ����������ƶ�
                    transformValue = Vector3.back * Time.deltaTime * speed;

                    break;
                case 3://��ɫ״̬����ʱ����ɫ�����������ƶ�
                    transformValue = Vector3.left * Time.deltaTime * speed;

                    break;
            }

            transform.Translate(transformValue, Space.World);//ƽ�ƽ�ɫ

        }
        transform.Rotate(Vector3.up, rotateValue);//��ת��ɫ
        oldState = State;//��ֵ��������һ�μ���
        State = currState;//��ֵ��������һ�μ���
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "xiansuo")
        {
            // PickUp();
            Ftips.SetActive(true);
            temp = other.gameObject;
            temp.GetComponent<Outline>().enabled = true;
        }
        if (other.tag == "jia")
        {
            // PickUp();
            Ftips.SetActive(true);
            temp = other.gameObject;
            temp.GetComponent<Outline>().enabled = true;
        }
        if (other.tag == "npc")
        {
            Ftips.SetActive(true);
            temp = other.gameObject;
        }
        if (other.tag == "box")
        {
            Ftips.SetActive(true);
        }
        if (other.tag == "emeny")
        {
            IsDeath = -2;
        }
        if (other.tag == "password1")
        {
            Ftips.SetActive(true);
            temp = other.gameObject;
        }
        if (other.tag == "password2")
        {
            Ftips.SetActive(true);
            temp = other.gameObject;
        }
        if (other.tag == "effect")
        {
            Etips.SetActive(true);
            temp = other.gameObject;
        }
        if (other.tag == "xiangzi")
        {
            Ftips.SetActive(true);
            temp = other.gameObject;
        }
        if (other.tag == "final") { Etips.SetActive(true); temp = other.gameObject; }
        if (other.tag == "chuansong") { Etips.SetActive(true); temp = other.gameObject; }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "xiansuo") { Ftips.SetActive(false); 
            temp.GetComponent<Outline>().enabled = false; }
        if (other.tag == "npc") { Ftips.SetActive(false);  }
        if (other.tag == "box") { Ftips.SetActive(false);  }
        if (other.tag == "emeny")
        {
            IsDeath = 2;
        }
        if (other.tag == "password1")
        {
            Ftips.SetActive(false);

        }
        if (other.tag == "password2")
        {
            Ftips.SetActive(true);
            temp = other.gameObject;
        }
        if (other.tag == "effect")
        {
            Etips.SetActive(false);
        }
        if (other.tag == "jia")
        {
            // PickUp();
            Ftips.SetActive(false);
            
            temp.GetComponent<Outline>().enabled = false;
        }
        if (other.tag == "xiangzi")
        {
            Ftips.SetActive(false);
        }
        if (other.tag == "final") { Ftips.SetActive(false);  }
        if (other.tag == "chuansong") { Etips.SetActive(false); }
    }
    public void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.F) && Ftips.activeInHierarchy)
        {

            if (temp.tag == "xiansuo")
            {
                //Destroy(temp);
                Ftips.SetActive(false);
              
                
            }
            if (temp.tag == "xiansuo")
            {

                Ftips.SetActive(false);

            }
            if (temp.tag == "box")
            {
                Ftips.SetActive(false);
            }
            if (temp.tag == "final")
            {
                Ftips.SetActive(false);
                Win_ui.SetActive(true);
            }
            if (temp.tag == "password1")
            {
                Ftips.SetActive(false);
                password1_ui.SetActive(true);
            }
            if (temp.tag == "password2")
            {
                Ftips.SetActive(false);
                password2_ui.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && Etips.activeInHierarchy)
        {
            if (temp.tag == "chuansong"){
                Etips.SetActive(false);
                SceneManager.LoadScene(sceneName);

            }
        }
        if (Input.GetKeyDown(KeyCode.E) && Etips.activeInHierarchy)
        {
            if (temp.tag == "effect")
            {
                Etips.SetActive(false);
                Destroy(temp);
                Invoke("sce", 1.5f);

            }
        }
    }
  public void sce()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ToPassword()
    {
        if (Input.GetKeyDown("F") && Ftips.activeInHierarchy)
        {
           
        }
    }
    public void Talk()
    {
       
        if (Input.GetKeyDown("F") && Etips.activeInHierarchy)
        {
            if (temp.tag == "npc")
            {
                Ftips.SetActive(false);
            }
            
        }
    }
   public void ToDeath()
    {
        if (IsDeath < 0)
        {

            animator.Play("Death");
            Invoke("fun", 1.5f);
         
        }
    }
    public void fun()
    {
        Time.timeScale = 0f;
        False_ui.SetActive(true);
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGround)
            {
                rb.AddForce(Vector3.up * speed);
                animator.SetBool("Jump", true);
               // IsGround = false;

               
            }
        }
    }
    public void IsGrounded()
    {

    }
}


