using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Professor.Class;

public class MonsterScript : MonoBehaviour
{

    // Use this for initialization
    public GameObject CombatPanel;
    public GameObject Player;
    public int MonsterType;
    Animator anim;

    private bool encounter = false;
    public CharacterOBJ Monsterobj;
    public bool moveEnabled = true;
    Animator Panim;
    

    void Start()
    {        
        anim = GetComponent<Animator>();
        Monsterobj = new CharacterOBJ(MonsterType);
        CombatPanel.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (moveEnabled)
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DataManger.SetupCombat(CombatPanel, Player, Monsterobj, anim, gameObject);
    }
}
