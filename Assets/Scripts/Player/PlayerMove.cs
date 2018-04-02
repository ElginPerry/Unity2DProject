using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float moveSpeed = 10f;
    public float hSpeed = 0;
    public float vSpeed = 0;
    public bool moveEnabled = true;

    Animator animator;    
    // Use this for initialization
    void Start () {        
        animator = GetComponent<Animator>();
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
