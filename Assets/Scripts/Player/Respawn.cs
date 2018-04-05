using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GameObject go = GameObject.Instantiate((GameObject)Resources.Load("FantasyArcher_01"), Vector3.zero, Quaternion.identity, GameObject.Find("Monsters").GetComponent<Transform>());
        go.transform.localPosition = new Vector3(5.0f, -4.0f, 5.0f);
        go.transform.localScale = new Vector3(.18f, .18f, 1f);
        go.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
