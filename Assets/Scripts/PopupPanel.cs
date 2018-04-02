using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupPanel : MonoBehaviour {

    // Use this for initialization
    public GameObject POPUPPanel;
    public GameObject Player;
    public GameObject PanelText;

    private Text t;

    void Start ()
    {
        POPUPPanel.SetActive(value: false);//This keep the panel inactive
        t = PanelText.GetComponent<Text>();      
    }

    // Update is called once per frame
    private void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMove script = (PlayerMove)GameObject.Find("Player").GetComponent("PlayerMove");
        script.moveEnabled = false;
        DataManger.playerobj.Health++;
        t.text = DataManger.playerobj.Health.ToString();
        if (other.gameObject.CompareTag("Player"))
        {
            POPUPPanel.SetActive(true);            
        }
    }
}
