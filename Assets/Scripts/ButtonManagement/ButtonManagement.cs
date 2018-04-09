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
        List<ItemObj> noHave = DataManger.AllItems.Except(DataManger.playerItems).ToList();
        float cnt = noHave.Count;
        int f = Mathf.RoundToInt(Random.Range(0, cnt));
        ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).LootImage.sprite = noHave[f].Sprite;
        string Loottxt = DataManger.AllItems[f].Name + "\n +" + DataManger.lootInfo.EXP + " EXP";
        ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).LootText.text = Loottxt;
        ItemObj newitem = noHave[f];
        int Order = DataManger.playerItems.FindAll(x => x.Sprite == null).OrderBy(x => x.Order).First<ItemObj>().Order;
        DataManger.playerItems[Order] = newitem;
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
