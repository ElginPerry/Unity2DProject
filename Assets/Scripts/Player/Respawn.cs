﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Professor.Class;

public class Respawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        foreach (RespawnObj ro in DataManger.respawnObjs)
        {
            if (ro.Process)
            {
                ro.RespawnTime -= 1;
                if (ro.RespawnTime == 0)
                {
                    GameObject go = GameObject.Instantiate((GameObject)Resources.Load("Monsters/" + ro.PreFabName), Vector3.zero, Quaternion.identity, GameObject.Find("Monsters").GetComponent<Transform>());
                    go.transform.localPosition = ro.position;
                    go.GetComponent<SpriteRenderer>().sortingOrder = 2;
                }
            }
        }
    }
}
