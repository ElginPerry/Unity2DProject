using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Professor.Class;
using System.Linq;

public class ButtonManagement : MonoBehaviour {
        
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
        List<ItemObj> noHave = DataManger.AllItems;
        float cnt = noHave.Count;
        int f = Mathf.RoundToInt(Random.Range(0, cnt-1));
        ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).LootImage.sprite = noHave[f].Sprite;
        string Loottxt = DataManger.AllItems[f].Name + "\n +" + DataManger.lootInfo.EXP + " EXP";
        ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).LootText.text = Loottxt;

        ItemObj newitem = new ItemObj();
        newitem = noHave[f];

        int Order = DataManger.playerItems.FindAll(x => x.ItemNumber == 0).OrderBy(x => x.Order).First<ItemObj>().Order;
        DataManger.playerItems[Order].ItemNumber = newitem.ItemNumber;
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
}
