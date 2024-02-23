using Fungus;
using UnityEngine;

public class Chat : MonoBehaviour
{
    [Header("npc���֣�����Block����һ��")]
    public string npcName;

    private Flowchart flowchart;
    private bool canSay;


    void Start()
    {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
    }
    private void Update()
    {
        //��갴����������Ի�����
       
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
        //�����⵽��ҽ��봥����Χ
        if (other.tag.Equals("Player"))
        {
            canSay = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //�����⵽����뿪������Χ
        if (other.tag.Equals("Player"))
        {
            canSay = false;
        }
    }
}