using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

    public float moveSpeed = 10f;
    public float hSpeed = 0;
    public float vSpeed = 0;
    public bool moveEnabled = true;
    private Image Pheatlh;

    Animator animator;    
    // Use this for initialization
    void Start () {        
        animator = GetComponent<Animator>();
        Pheatlh = gameObject.transform.Find("Canvas").transform.Find("HealthBar").GetComponent<Image>();
        GameObject.Find("CombatPanel").SetActive(false);
    }

    private void Update()
    {
        if (moveEnabled)
        {
            if (DataManger.playerobj.MaxHealth > DataManger.playerobj.Health)
            {
                DataManger.playerobj.Health += DataManger.playerobj.Heal * .02f;
                if (DataManger.playerobj.Health > DataManger.playerobj.MaxHealth)
                {
                    DataManger.playerobj.Health = DataManger.playerobj.MaxHealth;
                }
                Pheatlh.rectTransform.sizeDelta = new Vector2((DataManger.playerobj.Health/DataManger.playerobj.MaxHealth)*5, 1);
            }
            

        }
    }

    // Update is called once per frame
    private void FixedUpdate () {

        if (moveEnabled)
        {
            if (Input.GetButton("Horizontal"))
            {
                transform.localPosition += Input.GetAxis("Horizontal") * transform.right * moveSpeed;
                hSpeed = Input.GetAxis("Horizontal");
            }
            else
            {
                hSpeed = 0;
            }
            animator.SetFloat("hSpeed", hSpeed);

            if (Input.GetButton("Vertical"))
            {
                transform.localPosition += Input.GetAxis("Vertical") * transform.up * moveSpeed;
                vSpeed = Input.GetAxis("Vertical");
            }
            else
            {
                vSpeed = 0;
            }
            animator.SetFloat("vSpeed", vSpeed);
        }

    }
}
