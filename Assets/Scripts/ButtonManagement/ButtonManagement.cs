using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Professor.Class;
using System.Linq;

public class ButtonManagement : MonoBehaviour {
    ItemObj bonus;

    public void ExitClicked()
    {
        PlayerMove script = (PlayerMove)GameObject.Find("Player").GetComponent("PlayerMove");
        script.moveEnabled = true;
        GameObject.Find("POPUPPanel").SetActive(false);
        
    }

    public void OkClicked()
    {
        PlayerMove script = (PlayerMove)GameObject.Find("Player").GetComponent("PlayerMove");
        script.moveEnabled = true;
        GameObject.Find("POPUPPanel").SetActive(false);

    }

    public void LootChestClicked()
    {
        GameObject LootObj = ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).LootObj;
        LootObj.SetActive(false);
        GameObject DisplayLootObj = ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).DisplayLoot;
        DisplayLootObj.SetActive(true);

        //Filter Items in List - TODO
        List<ItemObj> noHave = DataManger.AllItems.FindAll(x => x.EXP <= DataManger.playerlevelobj.Exp);
        float cnt = noHave.Count;
        int f = Mathf.RoundToInt(Random.Range(0, cnt - 1));
        if (DataManger.playerItems.FindAll(x => x.ItemNumber == noHave[f].ItemNumber).Count > 0 || DataManger.EquipedItems.FindAll(x => x.ItemNumber == noHave[f].ItemNumber).Count > 0)
        {
            ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).LootImage.sprite = ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).LootGoldimage;
            string Loottxt = "+" + DataManger.lootInfo.EXP + " EXP";
            Loottxt += "\n +" + DataManger.lootInfo.EXP + " Gold";
            DataManger.playerobj.Gold += DataManger.lootInfo.EXP;
            ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).LootText.text = Loottxt;
        }
        else
        {
            ItemObj newitem = new ItemObj();
            newitem = noHave[f];

            int Order = DataManger.playerItems.FindAll(x => x.ItemNumber == 0).OrderBy(x => x.Order).First<ItemObj>().Order;
            DataManger.playerItems[Order].ItemNumber = newitem.ItemNumber;

            ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).LootImage.sprite = noHave[f].Sprite;
            string Loottxt = noHave[f].Name + "\n +" + DataManger.lootInfo.EXP + " EXP";
            ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).LootText.text = Loottxt;
        }        
    }

    public void CollectLoot()
    {
        foreach (RespawnObj ro in DataManger.respawnObjs)
        {
            if (!ro.Process)
            {
                ro.Process = true;
            }
        }
        GameObject DisplayLootObj = ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).DisplayLoot;
        DisplayLootObj.SetActive(false);
    }

    public void ToggleInventory()
    {
        GameObject InvObj = ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).InventoryObj;

        if (InvObj.activeSelf)
        {
            InvObj.SetActive(false);
        }
        else
        {
            DataManger.populatePlayerStats();
            DataManger.populateInventory();
            InvObj.SetActive(true);
        }
    }

    public void ToggleSettings()
    {
        GameObject settingsPanel = ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).SettingsPanel;

        if (settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(false);
        }
        else
        {
            settingsPanel.SetActive(true);
        }
    }

    public void CloseSettings()
    {
        GameObject.Find("SettingsPanel").SetActive(false);
    }

    public void ExitGameClicked()
    {
        Application.Quit();
    }
        
    public void MeleeClicked()
    {
        bonus = DataManger.GearBonus();
        DataManger.playerobj.DefaultAttack = "DaggerProjectile";
        DataManger.playerobj.Damage = DataManger.playerobj.MeleeAtk + bonus.MeleeAtk;
    }

    public void FireClicked()
    {
        bonus = DataManger.GearBonus();
        DataManger.playerobj.DefaultAttack = "FireballProjectile";
        DataManger.playerobj.Damage = DataManger.playerobj.FireAtk + bonus.FireAtk;
    }

    public void IceClicked()
    {
        bonus = DataManger.GearBonus();
        DataManger.playerobj.DefaultAttack = "IceBallProjectile";
        DataManger.playerobj.Damage = DataManger.playerobj.IceAtk + bonus.IceAtk;
    }

    public void HealClicked()
    {
        bonus = DataManger.GearBonus();
        float increase = DataManger.playerobj.Heal + bonus.Heal * 10;
        if (DataManger.playerobj.MaxHealth < DataManger.playerobj.Health + increase)
        {
            increase = DataManger.playerobj.MaxHealth - DataManger.playerobj.Health;
        }
        increase = Mathf.Round(increase);
        DataManger.playerobj.Health += increase;
    }
}
