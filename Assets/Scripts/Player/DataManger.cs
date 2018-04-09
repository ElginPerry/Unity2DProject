﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Professor.Class;


public class DataManger : MonoBehaviour {

    public static CharacterOBJ playerobj = new CharacterOBJ();
    public static PlayerLevelOBJ playerlevelobj = new PlayerLevelOBJ();
    public static List<RespawnObj> respawnObjs = new List<RespawnObj>();
    public static MovementObj movementObj = new MovementObj();
    public static List<ItemObj> AllItems = new List<ItemObj>();
    public static AudioSource audioSource = new AudioSource();
    public static LootInfo lootInfo = new LootInfo();
    public static List<ItemObj> playerItems = new List<ItemObj>();




    public static void SetupCombat(GameObject CombatPanel, GameObject Player, CharacterOBJ Monsterobj, Animator anim, GameObject Monster)
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

            Pname.text = DataManger.playerobj.Name;
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

    public static void populatePlayerStats()
    {
        GameObject InvObj = ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).InventoryObj;
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
        Text PMhealth;

        Pname = InvObj.transform.Find("PlayerStats").transform.Find("Name").GetComponent<Text>();
        Phealth = InvObj.transform.Find("PlayerStats").transform.Find("HealthValue").GetComponent<Text>();
        PMhealth = InvObj.transform.Find("PlayerStats").transform.Find("MaxHealthValue").GetComponent<Text>();
        Pmeleeatk = InvObj.transform.Find("PlayerStats").transform.Find("MeleeAtkValue").GetComponent<Text>();
        Pmeleedef = InvObj.transform.Find("PlayerStats").transform.Find("MeleeDefValue").GetComponent<Text>();
        Pfireatk = InvObj.transform.Find("PlayerStats").transform.Find("FireAtkValue").GetComponent<Text>();
        Pfiredef = InvObj.transform.Find("PlayerStats").transform.Find("FireDefValue").GetComponent<Text>();
        Piceatk = InvObj.transform.Find("PlayerStats").transform.Find("IceAtkValue").GetComponent<Text>();
        Picedef = InvObj.transform.Find("PlayerStats").transform.Find("IceDefValue").GetComponent<Text>();
        Paware = InvObj.transform.Find("PlayerStats").transform.Find("AwarenessValue").GetComponent<Text>();
        Pheal = InvObj.transform.Find("PlayerStats").transform.Find("HealValue").GetComponent<Text>();

        Pname.text = DataManger.playerobj.Name;
        Phealth.text = DataManger.playerobj.Health.ToString();
        PMhealth.text = DataManger.playerobj.MaxHealth.ToString();
        Pmeleeatk.text = DataManger.playerobj.MeleeAtk.ToString();
        Pmeleedef.text = DataManger.playerobj.MeleeDef.ToString();
        Pfireatk.text = DataManger.playerobj.FireAtk.ToString();
        Pfiredef.text = DataManger.playerobj.FireDef.ToString();
        Piceatk.text = DataManger.playerobj.IceAtk.ToString();
        Picedef.text = DataManger.playerobj.IceDef.ToString();
        Paware.text = DataManger.playerobj.Awareness.ToString();
        Pheal.text = DataManger.playerobj.Heal.ToString();

    }

    public static void populateInventory()
    {
        GameObject InvObj = ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).InventoryObj;
        Transform InvItems = InvObj.transform.Find("InventoryContain").transform.Find("InventoryItems");
        for (int i = 0; i < 24; i++)
        {
            if (playerItems[i].Sprite != null)
            {
                InvItems.transform.Find("Image (" + i.ToString() + ")").GetComponent<Image>().sprite = playerItems[i].Sprite;
                InvItems.transform.Find("Text (" + i.ToString() + ")").GetComponent<Text>().text = playerItems[i].Name;
            }
        }
    }

    public static void DeathScript(GameObject player, GameObject monster, CharacterOBJ Monsterobj, GameObject CombatPanel)
    {
        if (Monsterobj.Health <= 0)
        {
            lootInfo.EXP = Monsterobj.EXP;
            lootInfo.Name = Monsterobj.Name;
            RespawnObj ro = new RespawnObj();
            ro.PreFabName = Monsterobj.PreFab;
            ro.position = Monsterobj.position;
            ro.RespawnTime = Monsterobj.Respawn;
            ro.Process = false;
            DataManger.playerlevelobj.Exp += Monsterobj.EXP;
            DataManger.respawnObjs.Add(ro);             
            Destroy(monster);
            print("EXP:" + DataManger.playerlevelobj.Exp.ToString());
            Combat cscript = (Combat)CombatPanel.GetComponent("Combat");
            cscript.Resume();
            CheckLoot();
        }
        
        if (DataManger.playerobj.Health <= 0)
        {
            player.transform.localPosition = DataManger.playerobj.position;
            Combat cscript = (Combat)CombatPanel.GetComponent("Combat");
            cscript.Resume();
        }

    }

    public static void CheckLoot()
    {
        GameObject LootObj = ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).LootObj;
        LootObj.SetActive(true);
        GameObject DisplayLootObj = ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).DisplayLoot;
        DisplayLootObj.SetActive(false);
    }

    public static void Setupitems()
    {
        ItemObj it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Staffs/Aqua Staff");
        it.Name = "Ice Staff";
        it.IceAtk = 5;
        it.IceDef = 3;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Staffs/Red Staff");
        it.Name = "Fire Staff";
        it.Type = "Weapon";
        it.FireAtk = 5;
        it.FireDef = 3;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Staffs/Green Staff");
        it.Name = "Heal Staff";
        it.Type = "Weapon";
        it.Heal = 3;
        it.MeleeAtk = 3;
        it.MeleeDef = 3;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Staffs/Blue Staff");
        it.Name = "Greater Ice Staff";
        it.Type = "Weapon";
        it.IceAtk = 10;
        it.IceDef = 6;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Staffs/Yellow Staff");
        it.Name = "Greater Fire Staff";
        it.Type = "Weapon";
        it.FireAtk = 10;
        it.FireDef = 6;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Staffs/Purple Staff");
        it.Name = "Greater Heal Staff";
        it.Type = "Weapon";
        it.Heal = 6;
        it.MeleeAtk = 6;
        it.MeleeDef = 6;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Armor/23");
        it.Name = "Ice Chest";
        it.Type = "Chest";
        it.IceDef = 6;
        it.FireDef = 2;
        it.MeleeDef = 3;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Armor/24");
        it.Name = "Fire Chest";
        it.Type = "Chest";
        it.IceDef = 2;
        it.FireDef = 6;
        it.MeleeDef = 3;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Armor/27");
        it.Name = "Ice Boots";
        it.Type = "Feet";
        it.IceDef = 5;
        it.FireDef = 3;
        it.MeleeDef = 3;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Armor/28");
        it.Name = "Fire Boots";
        it.Type = "Feet";
        it.IceDef = 5;
        it.FireDef = 3;
        it.MeleeDef = 3;
        AllItems.Add(it);

        for (int i = 0; i < 24; i++)
        {
            it = new ItemObj();
            it.InvSlot = "Image (" + i.ToString() + ")";
            it.Order = i;
            playerItems.Add(it);
        }
    }

}

