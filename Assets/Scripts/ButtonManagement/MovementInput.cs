using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void onPointerLeftbtnDown()
    {
        DataManger.movementObj.hSpeed = -1;
    }
    public void onPointerLeftbtnUP()
    {
        DataManger.movementObj.hSpeed = 0;
    }
    public void onPointerRightbtnDown()
    {
        DataManger.movementObj.hSpeed = 1;
    }
    public void onPointerRightbtnUp()
    {
        DataManger.movementObj.hSpeed = 0;
    }
    public void onPointerUpbtnDown()
    {
        DataManger.movementObj.vSpeed = 1;
    }
    public void onPointerUpbtnUp()
    {
        DataManger.movementObj.vSpeed = 0;
    }
    public void onPointerDownbtnDown()
    {
        DataManger.movementObj.vSpeed = -1;
    }
    public void onPointerDownbtnUp()
    {
        DataManger.movementObj.vSpeed = 0;
    }
}
