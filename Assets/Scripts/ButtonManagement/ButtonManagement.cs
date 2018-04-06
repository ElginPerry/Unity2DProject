using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Professor.Class;

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
        foreach (RespawnObj ro in DataManger.respawnObjs)
        {
            if (!ro.Process)
            {
                ro.Process = true;
            }
        }

        GameObject LootObj = ((LevelManager)GameObject.FindWithTag("Canvas-LvL").GetComponent("LevelManager")).LootObj;
        LootObj.SetActive(false);
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
            InvObj.SetActive(true);
        }

    }
}
