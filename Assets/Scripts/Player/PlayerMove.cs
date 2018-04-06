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
        GameObject.Find("LootObj").SetActive(false);
        GameObject.Find("InventoryObj").SetActive(false);
        DataManger.playerobj.position = gameObject.transform.localPosition;
        DataManger.audioSource = GetComponent<AudioSource>();

        //Sound examples
        //float vol = Random.Range(volLowRange, volHighRange);
        //audioSource.PlayOneShot(shootSound, vol);
        //GameObject throwThis = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
        //throwThis.rigidbody.AddRelativeForce(new Vector3(0, 0, throwSpeed));
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
            if (Input.GetButton("Horizontal") || DataManger.movementObj.hSpeed !=0)
            {
                if (DataManger.movementObj.hSpeed != 0)
                {
                    hSpeed = DataManger.movementObj.hSpeed;
                }
                else if (Input.GetAxis("Horizontal") < 0)
                {
                    hSpeed = -1;
                }
                else
                {
                    hSpeed = 1;
                }                
            }
            else
            {
                hSpeed = 0;
            }
            animator.SetFloat("hSpeed", hSpeed);

            if (Input.GetButton("Vertical") || DataManger.movementObj.vSpeed != 0)
            {
                if (DataManger.movementObj.vSpeed != 0)
                {
                    vSpeed = DataManger.movementObj.vSpeed;
                }
                else if (Input.GetAxis("Vertical") < 0)
                {
                    vSpeed = -1;
                }
                else
                {
                    vSpeed = 1;
                }
            }
            else
            {
                vSpeed = 0;
            }
            animator.SetFloat("vSpeed", vSpeed);

            if (hSpeed != 0)
            {
                transform.localPosition += hSpeed * transform.right * moveSpeed;
            }
            if (vSpeed !=0)
            {
                transform.localPosition += vSpeed * transform.up * moveSpeed;
            }
        }
    }
}
