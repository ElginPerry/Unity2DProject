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

    public CharacterOBJ Monsterobj;
    public bool moveEnabled = true;
    Animator Panim;

    private Image Mheatlh;
    private Image Maxheatlh;
    void Start()
    {
        CombatPanel = ((LevelManager)GameObject.FindWithTag("LevelObject").GetComponent("LevelManager")).CombatPanel;
        Player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        Monsterobj = new CharacterOBJ(MonsterType);
        Monsterobj.position = gameObject.transform.localPosition;
        Monsterobj.Name = gameObject.name;
        Mheatlh = gameObject.transform.Find("Canvas").transform.Find("HealthBar").GetComponent<Image>();
        Maxheatlh = gameObject.transform.Find("Canvas").transform.Find("HealthBack").GetComponent<Image>();
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

            if (Monsterobj.MaxHealth > Monsterobj.Health)
            {
                Monsterobj.Health += Monsterobj.Heal * .02f;
                if (Monsterobj.Health > Monsterobj.MaxHealth)
                {
                    Monsterobj.Health = Monsterobj.MaxHealth;
                }
                Mheatlh.rectTransform.sizeDelta = new Vector2((Monsterobj.Health / Monsterobj.MaxHealth) * Maxheatlh.rectTransform.rect.width, 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DataManger.SetupCombat(CombatPanel, Player, Monsterobj, anim, gameObject);
    }
}
