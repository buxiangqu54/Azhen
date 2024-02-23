using Fungus;
using UnityEngine;

public class Chat : MonoBehaviour
{
    [Header("npc名字，需与Block名字一致")]
    public string npcName;

    private Flowchart flowchart;
    private bool canSay;


    void Start()
    {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
    }
    private void Update()
    {
        //鼠标按下左键触发对话方法
       
            Say();
        
    }
    void Say()
    {
        if (canSay)
        {
            if (flowchart.HasBlock(npcName))
            {
                flowchart.ExecuteBlock(npcName);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //如果检测到玩家进入触发范围
        if (other.tag.Equals("Player"))
        {
            canSay = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //如果检测到玩家离开触发范围
        if (other.tag.Equals("Player"))
        {
            canSay = false;
        }
    }
}