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

    private Text Pname;
    private Text Phealth;
    private Text Pmeleeatk;
    private Text Pmeleedef;
    private Text Pfireatk;
    private Text Pfiredef;
    private Text Piceatk;
    private Text Picedef;
    private Text Paware;
    private Text Pheal;

    private Image Pimg;
    private Image Mimg;

    private Text Mname;
    private Text Mhealth;
    private Text Mmeleeatk;
    private Text Mmeleedef;
    private Text Mfireatk;
    private Text Mfiredef;
    private Text Miceatk;
    private Text Micedef;
    private Text Maware;
    private Text Mheal;

    private bool encounter = false;
    public CharacterOBJ Monsterobj;
    public bool moveEnabled = true;
    Animator Panim;
    

    void Start()
    {
        Panim = GameObject.Find("Player").GetComponent<Animator>();
        anim = GetComponent<Animator>();
        Monsterobj = new CharacterOBJ(MonsterType);
        CombatPanel.SetActive(value: false);//This keep the panel inactive
        Pname = CombatPanel.transform.Find("PlayerStats").transform.Find("Name").GetComponent<Text>();
        Phealth = CombatPanel.transform.Find("PlayerStats").transform.Find("HealthValue").GetComponent<Text>();
        Pmeleeatk = CombatPanel.transform.Find("PlayerStats").transform.Find("MeleeAtkValue").GetComponent<Text>();
        Pmeleedef = CombatPanel.transform.Find("PlayerStats").transform.Find("MeleeDefValue").GetComponent<Text>();
        Pfireatk = CombatPanel.transform.Find("PlayerStats").transform.Find("FireAtkValue").GetComponent<Text>();
        Pfiredef = CombatPanel.transform.Find("PlayerStats").transform.Find("FireDefValue").GetComponent<Text>();
        Piceatk = CombatPanel.transform.Find("PlayerStats").transform.Find("IceAtkValue").GetComponent<Text>();
        Picedef = CombatPanel.transform.Find("PlayerStats").transform.Find("IceDefValue").GetComponent<Text>();
        Paware = CombatPanel.transform.Find("PlayerStats").transform.Find("AwarenessValue").GetComponent<Text>();
        Pheal = CombatPanel.transform.Find("PlayerStats").transform.Find("HealValue").GetComponent<Text>();

        Pimg = CombatPanel.transform.Find("ImagePlayer").GetComponent<Image>();
        Mimg = CombatPanel.transform.Find("ImageMonster").GetComponent<Image>();

        Mname = CombatPanel.transform.Find("MonsterStats").transform.Find("Name").GetComponent<Text>();
        Mhealth = CombatPanel.transform.Find("MonsterStats").transform.Find("HealthValue").GetComponent<Text>();
        Mmeleeatk = CombatPanel.transform.Find("MonsterStats").transform.Find("MeleeAtkValue").GetComponent<Text>();
        Mmeleedef = CombatPanel.transform.Find("MonsterStats").transform.Find("MeleeDefValue").GetComponent<Text>();
        Mfireatk = CombatPanel.transform.Find("MonsterStats").transform.Find("FireAtkValue").GetComponent<Text>();
        Mfiredef = CombatPanel.transform.Find("MonsterStats").transform.Find("FireDefValue").GetComponent<Text>();
        Miceatk = CombatPanel.transform.Find("MonsterStats").transform.Find("IceAtkValue").GetComponent<Text>();
        Micedef = CombatPanel.transform.Find("MonsterStats").transform.Find("IceDefValue").GetComponent<Text>();
        Maware = CombatPanel.transform.Find("MonsterStats").transform.Find("AwarenessValue").GetComponent<Text>();
        Mheal = CombatPanel.transform.Find("MonsterStats").transform.Find("HealValue").GetComponent<Text>();

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
        PlayerMove Pscript = (PlayerMove)GameObject.Find("Player").GetComponent("PlayerMove");
        Pscript.moveEnabled = false;
        MonsterScript Mscript = (MonsterScript)GetComponent("MonsterScript");
        Mscript.moveEnabled = false;
        anim.enabled = false;
        Panim.enabled = false;

        Pname.text = Player.name;
        Phealth.text = DataManger.playerobj.Health.ToString();
        Pmeleeatk.text = DataManger.playerobj.MeleeAtk.ToString();
        Pmeleedef.text = DataManger.playerobj.MeleeDef.ToString();
        Pfireatk.text = DataManger.playerobj.FireAtk.ToString();
        Pfiredef.text = DataManger.playerobj.FireDef.ToString();
        Piceatk.text = DataManger.playerobj.IceAtk.ToString();
        Picedef.text = DataManger.playerobj.IceDef.ToString();
        Paware.text = DataManger.playerobj.Awareness.ToString();
        Pheal.text = DataManger.playerobj.Heal.ToString();

        Mname.text = gameObject.name;
        DataManger.playerobj.Enemy = gameObject.name;
        Mhealth.text = Monsterobj.Health.ToString();
        Mmeleeatk.text = Monsterobj.MeleeAtk.ToString();
        Mmeleedef.text = Monsterobj.MeleeDef.ToString();
        Mfireatk.text = Monsterobj.FireAtk.ToString();
        Mfiredef.text = Monsterobj.FireDef.ToString();
        Miceatk.text = Monsterobj.IceAtk.ToString();
        Micedef.text = Monsterobj.IceDef.ToString();
        Maware.text = Monsterobj.Awareness.ToString();
        Mheal.text = Monsterobj.Heal.ToString();

        if (other.gameObject.CompareTag("Player"))
        {
            Sprite PlayerImg = Player.GetComponent<SpriteRenderer>().sprite;
            Sprite MonsterImg = gameObject.GetComponent<SpriteRenderer>().sprite;
            Pimg.sprite = PlayerImg;
            Mimg.sprite = MonsterImg;
            CombatPanel.SetActive(true);
        }
    }
}
