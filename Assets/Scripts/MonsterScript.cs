using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Professor.Class;

public class MonsterScript : MonoBehaviour
{

    // Use this for initialization
    public GameObject POPUPPanel;
    public GameObject Player;
    public int MonsterType;
    Animator anim;

    private Text t;
    private Text stats;
    private bool encounter = false;

    public CharacterOBJ Monsterobj;

    void Start()
    {
        anim = GetComponent<Animator>();
        Monsterobj = new CharacterOBJ(MonsterType);
        POPUPPanel.SetActive(value: false);//This keep the panel inactive
        t = POPUPPanel.transform.Find("PanelText").GetComponent<Text>();
        stats = POPUPPanel.transform.Find("StatsText").GetComponent<Text>();        
    }

    // Update is called once per frame
    private void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("WargbeastWalkup"))
        {
            //Do something if this particular state is palying
            transform.localPosition += .05f * transform.up * .08f;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("WargbeastWalkdown"))
        {
            transform.localPosition += -.05f * transform.up * .08f;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("WargbeastWalkright"))
        {
            transform.localPosition += .05f * transform.right * .08f;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("WargbeastWalkLeft"))
        {
            transform.localPosition += -.05f * transform.right * .08f;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("GhostWalkRight"))
        {
            transform.localPosition += .07f * transform.right * .08f;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("GhostWalkLeft"))
        {
            transform.localPosition += -.07f * transform.right * .08f;
        }
        if (encounter)
        {

        }
        else
        {
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMove script = (PlayerMove)GameObject.Find("Player").GetComponent("PlayerMove");
        script.moveEnabled = false;
        t.text = gameObject.name;
        stats.text = "Health: " + Monsterobj.Health.ToString() + "\n";
        stats.text += "Melee ATK: " + Monsterobj.MeleeAtk.ToString() + "\n";
        stats.text += "Melee DEF: " + Monsterobj.MeleeDef.ToString() + "\n";

        if (other.gameObject.CompareTag("Player"))
        {
            POPUPPanel.SetActive(true);
        }
    }
}
