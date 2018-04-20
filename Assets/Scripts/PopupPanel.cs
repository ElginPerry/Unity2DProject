using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupPanel : MonoBehaviour {

    // Use this for initialization
    public GameObject POPUPPanel;
    public GameObject Player;
    public GameObject PanelText;
    public float RequiredLevel;

    //private Text t;
    private Text stats;


    void Start ()
    {
        POPUPPanel.SetActive(value: false);//This keep the panel inactive
        //t = POPUPPanel.transform.Find("PanelText").GetComponent<Text>();
        stats = POPUPPanel.transform.Find("StatsText").GetComponent<Text>();

    }

// Update is called once per frame
private void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (RequiredLevel <= DataManger.playerlevelobj.Level)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else
        {
            PlayerMove script = (PlayerMove)GameObject.Find("Player").GetComponent("PlayerMove");
            script.moveEnabled = false;
            stats.text = "Your level: " + DataManger.playerlevelobj.Level.ToString();
            //t.text = Player.name;
            //stats.text = "Health: " + DataManger.playerobj.Health.ToString() + "\n";
            //stats.text += "Melee ATK: " + DataManger.playerobj.MeleeAtk.ToString() + "\n";
            //stats.text += "Melee DEF: " + DataManger.playerobj.MeleeDef.ToString() + "\n";

            if (other.gameObject.CompareTag("Player"))
            {
                POPUPPanel.SetActive(true);
            }
        }
    }
}
