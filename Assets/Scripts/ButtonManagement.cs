using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
