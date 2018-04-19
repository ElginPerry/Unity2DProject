using System.Collections;
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
    public static List<ItemObj> EquipedItems = new List<ItemObj>();
    public static List<LevelSettings> levelSettings = new List<LevelSettings>();




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

            ItemObj bonus = GearBonus();
            Pname.text = DataManger.playerobj.Name;
            Phealth.text = DataManger.playerobj.Health.ToString();
            Pmeleeatk.text = (DataManger.playerobj.MeleeAtk + bonus.MeleeAtk).ToString();
            Pmeleedef.text = (DataManger.playerobj.MeleeDef + bonus.MeleeDef).ToString();
            Pfireatk.text = (DataManger.playerobj.FireAtk + bonus.FireAtk).ToString();
            Pfiredef.text = (DataManger.playerobj.FireDef + bonus.FireDef).ToString();
            Piceatk.text = (DataManger.playerobj.IceAtk + bonus.IceAtk).ToString();
            Picedef.text = (DataManger.playerobj.IceDef + bonus.IceDef).ToString();
            Paware.text = (DataManger.playerobj.Awareness + bonus.Awareness).ToString();
            Pheal.text = (DataManger.playerobj.Heal + bonus.Heal).ToString();

            Pname.text = DataManger.playerobj.Name;
            Phealth.text = DataManger.playerobj.Health.ToString();
            if (bonus.MeleeAtk > 0)
            {
                Pmeleeatk.color = Color.green;
            }
            else if (bonus.MeleeAtk < 0)
            {
                Pmeleeatk.color = Color.red;
            }
            else
            {
                Pmeleeatk.color = Color.black;
            }
            Pmeleeatk.text = (DataManger.playerobj.MeleeAtk + bonus.MeleeAtk).ToString();
            if (bonus.MeleeDef > 0)
            {
                Pmeleedef.color = Color.green;
            }
            else if (bonus.MeleeDef < 0)
            {
                Pmeleedef.color = Color.red;
            }
            else
            {
                Pmeleedef.color = Color.black;
            }
            Pmeleedef.text = (DataManger.playerobj.MeleeDef + bonus.MeleeDef).ToString();
            if (bonus.FireAtk > 0)
            {
                Pfireatk.color = Color.green;
            }
            else if (bonus.FireAtk < 0)
            {
                Pfireatk.color = Color.red;
            }
            else
            {
                Pfireatk.color = Color.black;
            }
            Pfireatk.text = (DataManger.playerobj.FireAtk + bonus.FireAtk).ToString();
            if (bonus.FireDef > 0)
            {
                Pfiredef.color = Color.green;
            }
            else if (bonus.FireDef < 0)
            {
                Pfiredef.color = Color.red;
            }
            else
            {
                Pfiredef.color = Color.black;
            }
            Pfiredef.text = (DataManger.playerobj.FireDef + bonus.FireDef).ToString();
            if (bonus.IceAtk > 0)
            {
                Piceatk.color = Color.green;
            }
            else if (bonus.IceAtk < 0)
            {
                Piceatk.color = Color.red;
            }
            else
            {
                Piceatk.color = Color.black;
            }
            Piceatk.text = (DataManger.playerobj.IceAtk + bonus.IceAtk).ToString();
            if (bonus.IceDef > 0)
            {
                Picedef.color = Color.green;
            }
            else if (bonus.IceDef < 0)
            {
                Picedef.color = Color.red;
            }
            else
            {
                Picedef.color = Color.black;
            }
            Picedef.text = (DataManger.playerobj.IceDef + bonus.IceDef).ToString();
            if (bonus.Awareness > 0)
            {
                Paware.color = Color.green;
            }
            else if (bonus.Awareness < 0)
            {
                Paware.color = Color.red;
            }
            else
            {
                Paware.color = Color.black;
            }
            Paware.text = (DataManger.playerobj.Awareness + bonus.Awareness).ToString();
            if (bonus.Heal > 0)
            {
                Pheal.color = Color.green;
            }
            else if (bonus.Heal < 0)
            {
                Pheal.color = Color.red;
            }
            else
            {
                Pheal.color = Color.black;
            }
            Pheal.text = (DataManger.playerobj.Heal + bonus.Heal).ToString();

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
            //Pimg.sprite = PlayerImg;
            //Mimg.sprite = MonsterImg;
            Pimg.sprite = Pscript.CombatSprite; 
            Mimg.sprite = Mscript.CombatSprite;
            Mimg.color = Monster.GetComponent<SpriteRenderer>().color;
            //Mimg.SetNativeSize();
            //Mimg.rectTransform.sizeDelta = Monster.GetComponent<SpriteRenderer>().size;
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
        Text PLevel;
        Image PCurrentEXP;

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
        PLevel = InvObj.transform.Find("PlayerStats").transform.Find("LevelValue").GetComponent<Text>();
        PCurrentEXP = InvObj.transform.Find("PlayerStats").transform.Find("EXPBar").GetComponent<Image>();

        ItemObj bonus = GearBonus();

        Pname.text = DataManger.playerobj.Name; 
        Phealth.text = DataManger.playerobj.Health.ToString();
        if (bonus.MaxHealth > 0)
        {
            PMhealth.color = Color.green;
        }
        else if (bonus.MaxHealth < 0)
        {
            PMhealth.color = Color.red;
        }
        else
        {
            PMhealth.color = Color.black;
        }
        PMhealth.text = (DataManger.playerobj.MaxHealth + bonus.MaxHealth).ToString();
        if (bonus.MeleeAtk > 0)
        {
            Pmeleeatk.color = Color.green;
        }
        else if (bonus.MeleeAtk < 0)
        {
            Pmeleeatk.color = Color.red;
        }
        else
        {
            Pmeleeatk.color = Color.black;
        }
        Pmeleeatk.text = (DataManger.playerobj.MeleeAtk + bonus.MeleeAtk).ToString();
        if (bonus.MeleeDef > 0)
        {
            Pmeleedef.color = Color.green;
        }
        else if (bonus.MeleeDef < 0)
        {
            Pmeleedef.color = Color.red;
        }
        else
        {
            Pmeleedef.color = Color.black;
        }
        Pmeleedef.text = (DataManger.playerobj.MeleeDef + bonus.MeleeDef).ToString();
        if (bonus.FireAtk > 0)
        {
            Pfireatk.color = Color.green;
        }
        else if (bonus.FireAtk < 0)
        {
            Pfireatk.color = Color.red;
        }
        else
        {
            Pfireatk.color = Color.black;
        }
        Pfireatk.text = (DataManger.playerobj.FireAtk + bonus.FireAtk).ToString();
        if (bonus.FireDef > 0)
        {
            Pfiredef.color = Color.green;
        }
        else if (bonus.FireDef < 0)
        {
            Pfiredef.color = Color.red;
        }
        else
        {
            Pfiredef.color = Color.black;
        }
        Pfiredef.text = (DataManger.playerobj.FireDef + bonus.FireDef).ToString();
        if (bonus.IceAtk > 0)
        {
            Piceatk.color = Color.green;
        }
        else if (bonus.IceAtk < 0)
        {
            Piceatk.color = Color.red;
        }
        else
        {
            Piceatk.color = Color.black;
        }
        Piceatk.text = (DataManger.playerobj.IceAtk + bonus.IceAtk).ToString();
        if (bonus.IceDef > 0)
        {
            Picedef.color = Color.green;
        }
        else if (bonus.IceDef < 0)
        {
            Picedef.color = Color.red;
        }
        else
        {
            Picedef.color = Color.black;
        }
        Picedef.text = (DataManger.playerobj.IceDef + bonus.IceDef).ToString();
        if (bonus.Awareness > 0)
        {
            Paware.color = Color.green;
        }
        else if (bonus.Awareness < 0)
        {
            Paware.color = Color.red;
        }
        else
        {
            Paware.color = Color.black;
        }
        Paware.text = (DataManger.playerobj.Awareness + bonus.Awareness).ToString();
        if (bonus.Heal > 0)
        {
            Pheal.color = Color.green;
        }
        else if (bonus.Heal < 0)
        {
            Pheal.color = Color.red;
        }
        else
        {
            Pheal.color = Color.black;
        }
        Pheal.text = (DataManger.playerobj.Heal + bonus.Heal).ToString();
        PLevel.text = DataManger.playerlevelobj.Level.ToString();
        float PEpercent = DataManger.playerlevelobj.CurrentExp / DataManger.playerlevelobj.NeededExp;
        PCurrentEXP.rectTransform.sizeDelta = new Vector2(PEpercent * 100, 15);

    }

    public static void populateInventory()
    {
        GameObject InvObj = ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).InventoryObj;
        Transform InvItems = InvObj.transform.Find("InvPanel").transform.Find("InventoryContain").transform.Find("InventoryItems");
        for (int i = 0; i < 24; i++)
        {
            if (playerItems[i].ItemNumber != 0)
            {
                ItemObj it = DataManger.AllItems.Find(x => x.ItemNumber == playerItems[i].ItemNumber);
                InvItems.transform.Find("Image (" + i.ToString() + ")").GetComponent<Image>().sprite = it.Sprite;
                InvItems.transform.Find("Text (" + i.ToString() + ")").GetComponent<Text>().text = it.Name;
            }
        }
        Transform EquipedItemsTrans = InvObj.transform.Find("InvPanel").transform.Find("InventoryContain").transform.Find("InventoryItems").transform.Find("EquipedItems");
        foreach ( ItemObj eit in EquipedItems)
        {
            if (eit.ItemNumber != 0)
            {
                ItemObj ei = AllItems.Find(x => x.ItemNumber == eit.ItemNumber);
                EquipedItemsTrans.transform.Find(eit.InvSlot).GetComponent<Image>().sprite = ei.Sprite; 
            }

        }
        populateEquipedDisplay();
    }

    public static void populateEquipedDisplay()
    {
        Transform EquipedItemsTrans = GameObject.Find("EquipedDisplay").transform;
        foreach (ItemObj eit in EquipedItems)
        {
            if (eit.ItemNumber != 0)
            {
                ItemObj ei = AllItems.Find(x => x.ItemNumber == eit.ItemNumber);
                EquipedItemsTrans.transform.Find(eit.InvSlot).GetComponent<Image>().sprite = ei.Sprite;
            }
            else
            {
                EquipedItemsTrans.transform.Find(eit.InvSlot).GetComponent<Image>().sprite = null;
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
            respawnObjs.Add(ro);
            playerlevelobj.Exp += Monsterobj.EXP;
            LevelCalc();
            Destroy(monster);
            //print("EXP:" + DataManger.playerlevelobj.Exp.ToString());
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

    public static void SetupLevelRequirements()
    {
        for(int i = 1; i < 30; i++)
        {
            LevelSettings ls = new LevelSettings();
            ls.Level = i;
            ls.ExpRequired = 3000 * (i-1);
            levelSettings.Add(ls);
        }
    }

    public static void Setupitems()
    {
        int i = 0;
        ItemObj it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Staffs/Aqua Staff");
        it.Name = "Ice Staff";
        it.Type = "MainHand";
        it.AltType1 = "OffHand";
        it.IceAtk = 5;
        it.IceDef = 3;
        i++;
        it.ItemNumber = i;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Staffs/Red Staff");
        it.Name = "Fire Staff";
        it.Type = "MainHand";
        it.AltType1 = "OffHand";
        it.FireAtk = 5;
        it.FireDef = 3;
        i++;
        it.ItemNumber = i;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Staffs/Green Staff");
        it.Name = "Heal Staff";
        it.Type = "MainHand";
        it.AltType1 = "OffHand";
        it.Heal = 3;
        it.MeleeAtk = 3;
        it.MeleeDef = 3;
        i++;
        it.ItemNumber = i;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Staffs/Blue Staff");
        it.Name = "Greater Ice Staff";
        it.Type = "MainHand";
        it.AltType1 = "OffHand";
        it.IceAtk = 10;
        it.IceDef = 6;
        it.EXP = 3000;
        i++;
        it.ItemNumber = i;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Staffs/Yellow Staff");
        it.Name = "Greater Fire Staff";
        it.Type = "MainHand";
        it.AltType1 = "OffHand";
        it.FireAtk = 10;
        it.FireDef = 6;
        it.EXP = 3000;
        i++;
        it.ItemNumber = i;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Staffs/Purple Staff");
        it.Name = "Greater Heal Staff";
        it.Type = "MainHand";
        it.AltType1 = "OffHand";
        it.Heal = 6;
        it.MeleeAtk = 6;
        it.MeleeDef = 6;
        it.EXP = 3000;
        i++;
        it.ItemNumber = i++;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Armor/23");
        it.Name = "Ice Chest";
        it.Type = "Chest";
        it.IceDef = 6;
        it.FireDef = 2;
        it.MeleeDef = 3;
        i++;
        it.ItemNumber = i;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Armor/24");
        it.Name = "Fire Chest";
        it.Type = "Chest";
        it.IceDef = 2;
        it.FireDef = 6;
        it.MeleeDef = 3;
        i++;
        it.ItemNumber = i;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Armor/27");
        it.Name = "Ice Boots";
        it.Type = "Feet";
        it.IceDef = 5;
        it.FireDef = 3;
        it.MeleeDef = 3;
        i++;
        it.ItemNumber = i;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Armor/28");
        it.Name = "Fire Boots";
        it.Type = "Feet";
        it.IceDef = 5;
        it.FireDef = 3;
        it.MeleeDef = 3;
        i++;
        it.ItemNumber = i;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Armor/31");
        it.Name = "Shield";
        it.Type = "MainHand";
        it.AltType1 = "OffHand";
        it.IceDef = 2;
        it.FireDef = 2;
        it.MeleeDef = 6;
        i++;
        it.ItemNumber = i;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Armor/30");
        it.Name = "Great Shield";
        it.Type = "MainHand";
        it.AltType1 = "OffHand";
        it.IceDef = 8;
        it.FireDef = 8;
        it.MeleeDef = 8;
        it.EXP = 6000;
        i++;
        it.ItemNumber = i++;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Armor/29");
        it.Name = "Ice Shield";
        it.Type = "MainHand";
        it.AltType1 = "OffHand";
        it.IceDef = 10;
        it.FireDef = -3;
        it.MeleeDef = 5;
        it.EXP = 3000;
        i++;
        it.ItemNumber = i++;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Armor/32");
        it.Name = "Fire Shield";
        it.Type = "MainHand";
        it.AltType1 = "OffHand";
        it.IceDef = -3;
        it.FireDef = 10;
        it.MeleeDef = 5;
        it.EXP = 3000;
        i++;
        it.ItemNumber = i++;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Armor/19");
        it.Name = "Awareness Ring";
        it.Type = "Potion (0)";
        it.AltType1 = "Potion (1)";
        it.AltType2 = "Potion (2)";
        it.Awareness = 10;
        it.EXP = 3000;
        i++;
        it.ItemNumber = i;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Armor/18");
        it.Name = "Greater Awareness Ring";
        it.Type = "Potion (0)";
        it.AltType1 = "Potion (1)";
        it.AltType2 = "Potion (2)";
        it.Awareness = 20;
        it.EXP = 6000;
        i++;
        it.ItemNumber = i;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Potions/37");
        it.Name = "Healing Potion";
        it.Type = "Potion (0)";
        it.AltType1 = "Potion (1)";
        it.AltType2 = "Potion (2)";
        it.Heal = 10;
        i++;
        it.ItemNumber = i;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Potions/33");
        it.Name = "Utility Atack Potion";
        it.Type = "Potion (0)";
        it.AltType1 = "Potion (1)";
        it.AltType2 = "Potion (2)";
        it.MeleeAtk = 3;
        it.FireAtk = 3;
        it.IceAtk = 3;
        i++;
        it.ItemNumber = i++;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Potions/34");
        it.Name = "Melee Potion";
        it.Type = "Potion (0)";
        it.AltType1 = "Potion (1)";
        it.AltType2 = "Potion (2)";
        it.MeleeAtk = 6;
        it.FireAtk = -2;
        it.IceAtk = -2;
        it.EXP = 3000;
        i++;
        it.ItemNumber = i;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Potions/35");
        it.Name = "Element Potion";
        it.Type = "Potion (0)";
        it.AltType1 = "Potion (1)";
        it.AltType2 = "Potion (2)";
        it.MeleeAtk = -2;
        it.FireAtk = 3;
        it.IceAtk = 3;
        it.EXP = 3000;
        i++;
        it.ItemNumber = i;
        AllItems.Add(it);

        it = new ItemObj();
        it.Sprite = Resources.Load<Sprite>("Items/Potions/36");
        it.Name = "Mighty Potion";
        it.Type = "Potion (0)";
        it.AltType1 = "Potion (1)";
        it.AltType2 = "Potion (2)";
        it.MeleeAtk = 3;
        it.FireAtk = 3;
        it.IceAtk = 3;
        it.MeleeDef = 3;
        it.FireDef = 3;
        it.IceDef = 3; 
        it.EXP = 6000;
        i++;
        it.ItemNumber = i;
        AllItems.Add(it);

    }

    public static void SetupInventory()
    {
        for (int i = 0; i < 24; i++)
        {
            ItemObj it = new ItemObj();
            it.InvSlot = "Image (" + i.ToString() + ")";
            it.Order = i;
            playerItems.Add(it);
        }

        for (int i = 0; i < 8; i++)
        {
            ItemObj it = new ItemObj();
            if (i == 0)
            {
                it.InvSlot = "Chest";
            }
            else if (i == 1)
            {
                it.InvSlot = "Head";
            }
            else if (i == 2)
            {
                it.InvSlot = "OffHand";
            }
            else if (i == 3)
            {
                it.InvSlot = "MainHand";
            }
            else if (i == 4)
            {
                it.InvSlot = "Feet";
            }
            else if (i == 5)
            {
                it.InvSlot = "Potion (0)";
            }
            else if (i == 6)
            {
                it.InvSlot = "Potion (1)";
            }
            else if (i == 7)
            {
                it.InvSlot = "Potion (2)";
            }
            it.Order = i;
            EquipedItems.Add(it);
        }
    }

    public static ItemObj GearBonus()
    {
        ItemObj bonus = new ItemObj();
        foreach (ItemObj it in EquipedItems)
        {
            if (it.ItemNumber != 0)
            {
                ItemObj ait = AllItems.Find(x => x.ItemNumber == it.ItemNumber);
                bonus.MaxHealth += ait.MaxHealth;
                bonus.MeleeAtk += ait.MeleeAtk;
                bonus.MeleeDef += ait.MeleeDef;
                bonus.FireAtk += ait.FireAtk;
                bonus.FireDef += ait.FireDef;
                bonus.IceAtk += ait.IceAtk;
                bonus.IceDef += ait.IceDef;
                bonus.Awareness += ait.Awareness;
                bonus.Heal += ait.Heal;
            }
        }
        return bonus;
    }

    public static void LevelCalc()
    {
        int flag = 0;
        foreach( LevelSettings ls in levelSettings)
        {
            if (ls.ExpRequired < playerlevelobj.Exp)
            {
                playerlevelobj.Level = ls.Level;
                playerlevelobj.CurrentExp = playerlevelobj.Exp - ls.ExpRequired;
            }

            if (flag == 0 && ls.Level > playerlevelobj.Level)
            {
                flag = 1;
                playerlevelobj.NeededExp = ls.ExpRequired;
            }

        }
    }
}

