using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Professor.Class;


public class DataManger : MonoBehaviour {

    static public CharacterOBJ playerobj = new CharacterOBJ();
    static public PlayerLevelOBJ playerlevelobj = new PlayerLevelOBJ();
    static public List<RespawnObj> respawnObjs = new List<RespawnObj>();

    static public void SetupCombat(GameObject CombatPanel, GameObject Player, CharacterOBJ Monsterobj, Animator anim, GameObject Monster)
    {
        if (DataManger.playerobj.Health > 0 && Monsterobj.Health > 0)
        {
            Text Pname;
            Text Phealth;
            Text Pmeleeatk;
            Text Pmeleedef;
            Text Pfireatk;
            Text Pfiredef;
            Text Piceatk;
            Text Picedef;
            Text Paware;
            Text Pheal;
            Image Phealthbar;

            Image Pimg;
            Image Mimg;
            Animator Panim;

            Text Mname;
            Text Mhealth;
            Text Mmeleeatk;
            Text Mmeleedef;
            Text Mfireatk;
            Text Mfiredef;
            Text Miceatk;
            Text Micedef;
            Text Maware;
            Text Mheal;
            Image Mhealthbar;
            Panim = GameObject.Find("Player").GetComponent<Animator>();

            CombatPanel.SetActive(value: false);//This keep the panel inactive
            Pname = CombatPanel.transform.Find("PlayerStats").transform.Find("Name").GetComponent<Text>();
            Phealth = CombatPanel.transform.Find("PlayerStats").transform.Find("HealthValue").GetComponent<Text>();
            Pmeleeatk = CombatPanel.transform.Find("PlayerStats").transform.Find("MeleeAtkValue").GetComponent<Text>();
            Pmeleedef = CombatPanel.transform.Find("PlayerStats").transform.Find("MeleeDefValue").GetComponent<Text>();
            Pfireatk = CombatPanel.transform.Find("PlayerStats").transform.Find("FireAtkValue").GetComponent<Text>();
            Pfiredef = CombatPanel.transform.Find("PlayerStats").transform.Find("FireDefValue").GetComponent<Text>();
            Piceatk = CombatPanel.transform.Find("PlayerStats").transform.Find("IceAtkValue").GetComponent<Text>();
            Picedef = CombatPanel.transform.Find("PlayerStats").transform.Find("IceDefValue").GetComponent<Text>();
            Paware = CombatPanel.transform.Find("PlayerStats").transform.Find("AwarenessValue").GetComponent<Text>();
            Pheal = CombatPanel.transform.Find("PlayerStats").transform.Find("HealValue").GetComponent<Text>();

            Pimg = CombatPanel.transform.Find("ImagePlayer").GetComponent<Image>();
            Mimg = CombatPanel.transform.Find("ImageMonster").GetComponent<Image>();

            Phealthbar = CombatPanel.transform.Find("PlayerStats").transform.Find("HealthBar").GetComponent<Image>();
            Mhealthbar = CombatPanel.transform.Find("MonsterStats").transform.Find("HealthBar").GetComponent<Image>();

            Mname = CombatPanel.transform.Find("MonsterStats").transform.Find("Name").GetComponent<Text>();
            Mhealth = CombatPanel.transform.Find("MonsterStats").transform.Find("HealthValue").GetComponent<Text>();
            Mmeleeatk = CombatPanel.transform.Find("MonsterStats").transform.Find("MeleeAtkValue").GetComponent<Text>();
            Mmeleedef = CombatPanel.transform.Find("MonsterStats").transform.Find("MeleeDefValue").GetComponent<Text>();
            Mfireatk = CombatPanel.transform.Find("MonsterStats").transform.Find("FireAtkValue").GetComponent<Text>();
            Mfiredef = CombatPanel.transform.Find("MonsterStats").transform.Find("FireDefValue").GetComponent<Text>();
            Miceatk = CombatPanel.transform.Find("MonsterStats").transform.Find("IceAtkValue").GetComponent<Text>();
            Micedef = CombatPanel.transform.Find("MonsterStats").transform.Find("IceDefValue").GetComponent<Text>();
            Maware = CombatPanel.transform.Find("MonsterStats").transform.Find("AwarenessValue").GetComponent<Text>();
            Mheal = CombatPanel.transform.Find("MonsterStats").transform.Find("HealValue").GetComponent<Text>();

            PlayerMove Pscript = (PlayerMove)GameObject.Find("Player").GetComponent("PlayerMove");
            Pscript.moveEnabled = false;
            MonsterScript Mscript = (MonsterScript)Monster.GetComponent("MonsterScript");
            Mscript.moveEnabled = false;
            anim.enabled = false;
            Panim.enabled = false;

            Pname.text = Player.name;
            Phealth.text = DataManger.playerobj.Health.ToString();
            Pmeleeatk.text = DataManger.playerobj.MeleeAtk.ToString();
            Pmeleedef.text = DataManger.playerobj.MeleeDef.ToString();
            Pfireatk.text = DataManger.playerobj.FireAtk.ToString();
            Pfiredef.text = DataManger.playerobj.FireDef.ToString();
            Piceatk.text = DataManger.playerobj.IceAtk.ToString();
            Picedef.text = DataManger.playerobj.IceDef.ToString();
            Paware.text = DataManger.playerobj.Awareness.ToString();
            Pheal.text = DataManger.playerobj.Heal.ToString();

            float pch = DataManger.playerobj.Health / DataManger.playerobj.MaxHealth;
            Phealthbar.rectTransform.sizeDelta = new Vector2(pch * 100, 15);

            Mname.text = Monster.name;
            DataManger.playerobj.Enemy = Monster.name;
            Mhealth.text = Monsterobj.Health.ToString();
            Mmeleeatk.text = Monsterobj.MeleeAtk.ToString();
            Mmeleedef.text = Monsterobj.MeleeDef.ToString();
            Mfireatk.text = Monsterobj.FireAtk.ToString();
            Mfiredef.text = Monsterobj.FireDef.ToString();
            Miceatk.text = Monsterobj.IceAtk.ToString();
            Micedef.text = Monsterobj.IceDef.ToString();
            Maware.text = Monsterobj.Awareness.ToString();
            Mheal.text = Monsterobj.Heal.ToString();

            float mch = Monsterobj.Health / Monsterobj.MaxHealth;
            Mhealthbar.rectTransform.sizeDelta = new Vector2(mch * 100, 15);

            Sprite PlayerImg = Player.GetComponent<SpriteRenderer>().sprite;
            Sprite MonsterImg = Monster.GetComponent<SpriteRenderer>().sprite;
            Pimg.sprite = PlayerImg;
            Mimg.sprite = MonsterImg;
            CombatPanel.SetActive(true);
        }
        else
        {
            DeathScript(Player, Monster, Monsterobj, CombatPanel);
        }
        
    }

    static public void DeathScript(GameObject player, GameObject monster, CharacterOBJ Monsterobj, GameObject CombatPanel)
    {
        if (Monsterobj.Health <= 0)
        {
            RespawnObj ro = new RespawnObj();
            ro.PreFabName = Monsterobj.PreFab;
            ro.position = Monsterobj.position;
            ro.RespawnTime = Monsterobj.Respawn;
            DataManger.playerlevelobj.Exp += Monsterobj.EXP;
            DataManger.respawnObjs.Add(ro);
            Destroy(monster);
            print("EXP:" + DataManger.playerlevelobj.Exp.ToString());
        }
        
        if (DataManger.playerobj.Health <= 0)
        {
            player.transform.localPosition = DataManger.playerobj.position;
        }

        Combat cscript = (Combat)CombatPanel.GetComponent("Combat");
        cscript.Resume();
    }

    static public void CheckRespawns()
    {
        foreach (RespawnObj reo in respawnObjs)
        {

        }
    }
}

