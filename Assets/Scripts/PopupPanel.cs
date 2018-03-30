using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupPanel : MonoBehaviour {

    // Use this for initialization
    public GameObject POPUPPanel;
    public GameObject Player;
    void Start () {
        POPUPPanel.SetActive(value: false);//This keep the panel inactive
    }

    // Update is called once per frame
    private void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMove script = (PlayerMove)GameObject.Find("Player").GetComponent("PlayerMove");
        script.moveEnabled = false;
        print(other.gameObject.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            POPUPPanel.SetActive(true);            
        }
    }
}
