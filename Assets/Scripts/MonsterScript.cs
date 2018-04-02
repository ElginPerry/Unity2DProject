using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterScript : MonoBehaviour
{

    // Use this for initialization
    public GameObject POPUPPanel;
    public GameObject Player;
    public GameObject PanelText;
    Animator anim;

    private Text t;
    private bool encounter = false;



    void Start()
    {
        anim = GetComponent<Animator>();
        POPUPPanel.SetActive(value: false);//This keep the panel inactive
        t = PanelText.GetComponent<Text>();
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
        DataManger.playerobj.Health++;
        t.text = gameObject.name;
        if (other.gameObject.CompareTag("Player"))
        {
            POPUPPanel.SetActive(true);
        }
    }
}
