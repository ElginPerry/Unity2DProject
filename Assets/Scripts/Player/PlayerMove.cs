using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour {

    public float moveSpeed = 10f;
    public float hSpeed = 0;
    public float vSpeed = 0;
    public bool moveEnabled = true;
    public Sprite CombatSprite;
    private Image Pheatlh;
    private Image PExpD;
    private Text PLevel;
    private Vector3 target;
    private Vector3 mousepointer;
    public GameObject ClickImage;

    float distance = 100;
    float firerate = 0;
    Animator animator;
    Animator CIanim;
    CanvasGroup CG;
    // Use this for initialization
    void Start () {        
        animator = GetComponent<Animator>();
        CIanim = ClickImage.GetComponent<Animator>();
        Pheatlh = gameObject.transform.Find("Canvas").transform.Find("HealthBar").GetComponent<Image>();
        PExpD = gameObject.transform.Find("Canvas").transform.Find("ExpBar").GetComponent<Image>();
        PLevel = gameObject.transform.Find("Canvas").transform.Find("LevelPanel").transform.Find("Level").GetComponent<Text>();
        GameObject.Find("LootObj").SetActive(false);
        GameObject.Find("InventoryObj").SetActive(false);
        GameObject.Find("DisplayLoot").SetActive(false);
        GameObject.Find("SettingsPanel").SetActive(false);
        CG = gameObject.transform.Find("Canvas").transform.Find("ResultPanel").GetComponent<CanvasGroup>(); 

        DataManger.playerobj.position = gameObject.transform.localPosition;
        DataManger.audioSource = GetComponent<AudioSource>();
        DataManger.Setupitems();
        DataManger.SetupInventory();
        DataManger.SetupLevelRequirements();
        DataManger.LevelCalc();
        target = transform.position;
        ClickImage.transform.position = new Vector3(0, 0, -3);

        //Sound examples
        //float vol = Random.Range(volLowRange, volHighRange);
        //audioSource.PlayOneShot(shootSound, vol);
        //GameObject throwThis = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
        //throwThis.rigidbody.AddRelativeForce(new Vector3(0, 0, throwSpeed));
    }

    void Awake()
    {
       // VSync must be disabled
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        //Damage Panel Fade
        if (CG.alpha > 0)
        {
            CG.alpha -= .01f;
        }
        //Health Regen and Level display
        if (moveEnabled)
        {
            if (DataManger.playerobj.Health <= 0)
            {
                DataManger.DeathScript(gameObject, DataManger.playerobj);
            }
            else if (DataManger.playerobj.MaxHealth > DataManger.playerobj.Health)
            {
                DataManger.playerobj.Health += DataManger.playerobj.Heal * .02f;
                if (DataManger.playerobj.Health > DataManger.playerobj.MaxHealth)
                {
                    DataManger.playerobj.Health = DataManger.playerobj.MaxHealth;
                }                             
            }
            Pheatlh.rectTransform.sizeDelta = new Vector2((DataManger.playerobj.Health / DataManger.playerobj.MaxHealth) * 5, 1);
            PLevel.text = DataManger.playerlevelobj.Level.ToString();
            float PEpercent = DataManger.playerlevelobj.CurrentExp / DataManger.playerlevelobj.NeededExp;
            PExpD.rectTransform.sizeDelta = new Vector2(PEpercent * 5, .5f);
        }
    }

    // Update is called once per frame
    private void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }

        if (DataManger.movementObj.combatTarget != null && DataManger.playerobj.Damage != 0)
        {
            distance = Vector3.Distance(transform.position, DataManger.movementObj.combatTarget.transform.position);
            if (distance < 80 && firerate > 2)
            {
                GameObject go = GameObject.Instantiate((GameObject)Resources.Load("Projectile/" + DataManger.playerobj.DefaultAttack), Vector3.zero, Quaternion.identity, gameObject.transform);
                go.transform.localPosition = new Vector3(0f, 0f, 0f);
                go.AddComponent<PlayerProjectile>();
                PlayerProjectile pscript = (PlayerProjectile)go.GetComponent("PlayerProjectile");
                pscript.Damage = DataManger.playerobj.Damage;
                pscript.ProjectileSpd = DataManger.playerobj.ProjectileSpeed;
                firerate = 0;
            }
            firerate += Time.deltaTime;
        }

        if (moveEnabled)
        {
            if (Input.GetMouseButton(0) && !IsPointerOverUIObject())
            {
                mousepointer = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D hitCollider = Physics2D.OverlapPoint(mousepointer);
                if (hitCollider)
                {
                    if (hitCollider.gameObject.tag == "Monster")
                    {
                        //print(hitCollider.transform.name);
                        DataManger.movementObj.combatTarget = hitCollider.gameObject;
                        DataManger.movementObj.combatMonster = ((MonsterScript)DataManger.movementObj.combatTarget.GetComponent("MonsterScript")).Monsterobj;
                    }
                }
                else
                {
                    target = mousepointer;
                    target.z = transform.position.z;
                    ClickImage.transform.position = target;
                    CIanim.SetBool("Clicked", true);

                    float resX = target.x - transform.position.x;
                    float resY = target.y - transform.position.y;
                    if (target.x > transform.position.x && Mathf.Abs(resX) > Mathf.Abs(resY))
                    {
                        animator.SetFloat("vSpeed", 0);
                        animator.SetFloat("hSpeed", 1);
                    }
                    else if (target.x < transform.position.x && Mathf.Abs(resX) > Mathf.Abs(resY))
                    {
                        animator.SetFloat("vSpeed", 0);
                        animator.SetFloat("hSpeed", -1);
                    }
                    else if (target.y > transform.position.y && Mathf.Abs(resY) > Mathf.Abs(resX))
                    {
                        animator.SetFloat("hSpeed", 0);
                        animator.SetFloat("vSpeed", 1);
                    }
                    else if (target.y < transform.position.y && Mathf.Abs(resY) > Mathf.Abs(resX))
                    {
                        animator.SetFloat("hSpeed", 0);
                        animator.SetFloat("vSpeed", -1);
                    }
                    DataManger.movementObj.ClickMove = true;
                }
            }
            else
            {
                #region OldMOVE
                //DataManger.movementObj.ClickMove = false;
                //if (Input.GetButton("Horizontal") || DataManger.movementObj.hSpeed != 0)
                //{
                //    if (DataManger.movementObj.hSpeed != 0)
                //    {
                //        hSpeed = DataManger.movementObj.hSpeed;
                //    }
                //    else if (Input.GetAxis("Horizontal") < 0)
                //    {
                //        hSpeed = -1;
                //    }
                //    else
                //    {
                //        hSpeed = 1;
                //    }
                //}
                //else
                //{
                //    hSpeed = 0;
                //}


                //animator.SetFloat("hSpeed", hSpeed);

                //if (Input.GetButton("Vertical") || DataManger.movementObj.vSpeed != 0)
                //{
                //    if (DataManger.movementObj.vSpeed != 0)
                //    {
                //        vSpeed = DataManger.movementObj.vSpeed;
                //    }
                //    else if (Input.GetAxis("Vertical") < 0)
                //    {
                //        vSpeed = -1;
                //    }
                //    else
                //    {
                //        vSpeed = 1;
                //    }
                //}
                //else
                //{
                //    vSpeed = 0;
                //}
                //animator.SetFloat("vSpeed", vSpeed);

                //if (hSpeed != 0)
                //{
                //    transform.localPosition += hSpeed * transform.right * moveSpeed;
                //}
                //if (vSpeed != 0)
                //{
                //    transform.localPosition += vSpeed * transform.up * moveSpeed;
                //}
                #endregion
            }


            if (transform.position != target && CIanim.GetBool("Clicked"))
            {
                transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime );
            }
            else
            {
                animator.SetFloat("hSpeed", 0);
                animator.SetFloat("vSpeed", 0);
                ClickImage.transform.position = new Vector3(0, 0, -3);
                CIanim.SetBool("Clicked", false);
            }
          
        }
        else
        {
            target = transform.position;
            animator.SetFloat("hSpeed", 0);
            animator.SetFloat("vSpeed", 0);
            ClickImage.transform.position = new Vector3(0, 0, -3);
            CIanim.SetBool("Clicked", false);
        }
    }

    public static bool IsPointerOverGameObject()
    {
        //check mouse
        if (EventSystem.current.IsPointerOverGameObject())
            return true;

        //check touch
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
                return true;
        }

        return false;
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
