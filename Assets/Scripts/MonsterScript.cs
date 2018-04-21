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
    public float MoveSpeed;
    public Sprite CombatSprite;
    public float CombatLevel;
    public CharacterOBJ Monsterobj;
    public bool moveEnabled = true;

    Animator anim;

    Animator Panim;
    float distance = 100;
    float firerate = 100;

    private Image Mheatlh;
    private Image Maxheatlh;
    private Text LevelDisplay;
    private float MoveCnt = 1;
    private float MoveMod = 1;
    private SpriteRenderer SelectCircle;
    void Start()
    {
        CombatPanel = ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).CombatPanel;
        Player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        Monsterobj = new CharacterOBJ(MonsterType);
        Monsterobj.position = gameObject.transform.localPosition;
        Monsterobj.Name = gameObject.name;
        Mheatlh = gameObject.transform.Find("MonsterCanvas").transform.Find("HealthBar").GetComponent<Image>();
        Maxheatlh = gameObject.transform.Find("MonsterCanvas").transform.Find("HealthBack").GetComponent<Image>();
        LevelDisplay = gameObject.transform.Find("MonsterCanvas").transform.Find("LevelPanel").transform.Find("Level").GetComponent<Text>();
        SelectCircle = gameObject.transform.Find("SelectCircle").GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, Player.transform.position);
        if (distance < 70 && firerate > 4)
        {
            GameObject go = GameObject.Instantiate((GameObject)Resources.Load("Projectile/" + Monsterobj.Projectile), Vector3.zero, Quaternion.identity, gameObject.transform);
            go.transform.localPosition = new Vector3(0f, 0f, 0f);
            Projectile pscript = (Projectile)go.GetComponent("Projectile");
            pscript.Damage = Monsterobj.Damage;
            firerate = 0;
        }

        if (DataManger.movementObj.combatTarget == gameObject)
        {
            if (distance > 70)
            {
                DataManger.movementObj.combatTarget = null;
                SelectCircle.enabled = false;
            }
            else
            {
                SelectCircle.enabled = true;
            }
        }
        else
        {
            SelectCircle.enabled = false;
        }

        firerate += Time.deltaTime;

        if (moveEnabled)
        {
            if (1 == 1)
            {
                if (MoveCnt > 15)
                {
                    MoveCnt = 0;
                    MoveMod++;
                    if (MoveMod > 4)
                    {
                        MoveMod = 1;
                    }
                }
                if (MoveMod == 1)
                {
                    anim.SetBool("WalkUp", false);
                    anim.SetBool("WalkRight", false);
                    anim.SetBool("WalkLeft", false);
                    anim.SetBool("WalkDown", true);
                    transform.localPosition += -MoveSpeed * transform.up * .08f;
                }
                if (MoveMod == 2)
                {
                    anim.SetBool("WalkDown", false);
                    anim.SetBool("WalkUp", false);
                    anim.SetBool("WalkLeft", false);
                    anim.SetBool("WalkRight", true);
                    transform.localPosition += MoveSpeed * transform.right * .08f;
                }
                if (MoveMod == 3)
                {
                    anim.SetBool("WalkDown", false);
                    anim.SetBool("WalkRight", false);
                    anim.SetBool("WalkLeft", false);
                    anim.SetBool("WalkUp", true);
                    transform.localPosition += MoveSpeed * transform.up * .08f;
                }
                if (MoveMod == 4)
                {
                    anim.SetBool("WalkDown", false);
                    anim.SetBool("WalkUp", false);
                    anim.SetBool("WalkRight", false);
                    anim.SetBool("WalkLeft", true);
                    transform.localPosition += -MoveSpeed * transform.right * .08f;
                }
                MoveCnt += Time.deltaTime;
            }

            if (Monsterobj.MaxHealth > Monsterobj.Health)
            {
                Monsterobj.Health += Monsterobj.Heal * .02f;
                if (Monsterobj.Health > Monsterobj.MaxHealth)
                {
                    Monsterobj.Health = Monsterobj.MaxHealth;
                }
                Mheatlh.rectTransform.sizeDelta = new Vector2((Monsterobj.Health / Monsterobj.MaxHealth) * Maxheatlh.rectTransform.rect.width, 1);
                LevelDisplay.text = CombatLevel.ToString();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("Oops");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Vector3 vectorToTarget = Player.transform.position - transform.position;
        //float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) + 90;
        //Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);

        //GameObject go = GameObject.Instantiate((GameObject)Resources.Load("Projectile/FireBall"), Vector3.zero, Quaternion.identity, gameObject.transform);
        //go.transform.localPosition = new Vector3(0f, 0f, 0f);
        //Projectile pscript = (Projectile)go.GetComponent("Projectile");
        //pscript.Damage = Monsterobj.FireAtk; 
        //moveEnabled = false;
    }

    void OnTriggerEnter2DOld(Collider2D other)
    {
        GetComponent<AudioSource>().PlayScheduled(5);
        DataManger.SetupCombat(CombatPanel, Player, Monsterobj, anim, gameObject);
    }
}
