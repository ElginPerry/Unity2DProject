using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Combat : MonoBehaviour
{
    public Sprite MeleeAction;
    public Sprite FireAction;
    public Sprite IceAction;
    public Sprite HealAction;
    public Sprite NoAction;
    public GameObject playerStats;
    public GameObject monsterStats;

    Animator Panim;
    Animator Manim;
    public void MeleeClicked()
    {
        MeleeFun(1);
    }
    public void FireClicked()
    {
        FireFun(1);
    }
    public void IceClicked()
    {
        IceFun(1);
    }
    public void HealClicked()
    {
        HealFun(1);
    }
    public void EscapeClicked()
    {
        Resume();
    }

    public void Resume()
    {
        PlayerMove script = (PlayerMove)GameObject.Find("Player").GetComponent("PlayerMove");
        script.moveEnabled = true;
        MonsterScript mscript = (MonsterScript)GameObject.Find(DataManger.playerobj.Enemy).GetComponent("MonsterScript");
        mscript.moveEnabled = true;

        playerStats.transform.Find("Action").GetComponent<Image>().sprite = NoAction;
        monsterStats.transform.Find("Action").GetComponent<Image>().sprite = NoAction;
        monsterStats.transform.Find("Result").GetComponent<Text>().text = "";
        playerStats.transform.Find("Result").GetComponent<Text>().text = "";

        Animator Panim = GameObject.Find("Player").GetComponent<Animator>();
        Animator Manim = GameObject.Find(DataManger.playerobj.Enemy).GetComponent<Animator>();
        Panim.enabled = true;
        Manim.enabled = true;
        GameObject.Find("CombatPanel").SetActive(false);
    }

    public void MeleeFun(int who)
    {
        if (who == 1)
        {
            playerStats.transform.Find("Action").GetComponent<Image>().sprite = MeleeAction;
            monsterStats.transform.Find("Action").GetComponent<Image>().sprite = NoAction;
            playerStats.transform.Find("Turn").GetComponent<Image>().color = Color.red;
            monsterStats.transform.Find("Turn").GetComponent<Image>().color = Color.green;
            monsterStats.transform.Find("Result").GetComponent<Text>().text = "999";
            playerStats.transform.Find("Result").GetComponent<Text>().text = "";
            monsterStats.transform.Find("Result").GetComponent<Text>().color = Color.red;
        }
        else
        {
            monsterStats.transform.Find("Action").GetComponent<Image>().sprite = MeleeAction;
            playerStats.transform.Find("Action").GetComponent<Image>().sprite = NoAction;
            monsterStats.transform.Find("Turn").GetComponent<Image>().color = Color.red;
            playerStats.transform.Find("Turn").GetComponent<Image>().color = Color.green;
            playerStats.transform.Find("Result").GetComponent<Text>().text = "999";
            monsterStats.transform.Find("Result").GetComponent<Text>().text = "";
            playerStats.transform.Find("Result").GetComponent<Text>().color = Color.red;
        }
    }
    public void FireFun(int who)
    {
        if (who == 1)
        {
            playerStats.transform.Find("Action").GetComponent<Image>().sprite = FireAction;
            monsterStats.transform.Find("Action").GetComponent<Image>().sprite = NoAction;
            playerStats.transform.Find("Turn").GetComponent<Image>().color = Color.red;
            monsterStats.transform.Find("Turn").GetComponent<Image>().color = Color.green;
            monsterStats.transform.Find("Result").GetComponent<Text>().text = "999";
            playerStats.transform.Find("Result").GetComponent<Text>().text = "";
            monsterStats.transform.Find("Result").GetComponent<Text>().color = Color.red;
        }
        else
        {
            monsterStats.transform.Find("Action").GetComponent<Image>().sprite = FireAction;
            playerStats.transform.Find("Action").GetComponent<Image>().sprite = NoAction;
            playerStats.transform.Find("Turn").GetComponent<Image>().color = Color.green;
            monsterStats.transform.Find("Turn").GetComponent<Image>().color = Color.red;
            playerStats.transform.Find("Result").GetComponent<Text>().text = "999";
            monsterStats.transform.Find("Result").GetComponent<Text>().text = "";
            playerStats.transform.Find("Result").GetComponent<Text>().color = Color.red;
        }
    }
    public void IceFun(int who)
    {
        if (who == 1)
        {
            playerStats.transform.Find("Action").GetComponent<Image>().sprite = IceAction;
            monsterStats.transform.Find("Action").GetComponent<Image>().sprite = NoAction;
            playerStats.transform.Find("Turn").GetComponent<Image>().color = Color.red;
            monsterStats.transform.Find("Turn").GetComponent<Image>().color = Color.green;
            monsterStats.transform.Find("Result").GetComponent<Text>().text = "999";
            playerStats.transform.Find("Result").GetComponent<Text>().text = "";
            monsterStats.transform.Find("Result").GetComponent<Text>().color = Color.red;

        }
        else
        {
            monsterStats.transform.Find("Action").GetComponent<Image>().sprite = IceAction;
            playerStats.transform.Find("Action").GetComponent<Image>().sprite = NoAction;
            playerStats.transform.Find("Turn").GetComponent<Image>().color = Color.green;
            monsterStats.transform.Find("Turn").GetComponent<Image>().color = Color.red;
            playerStats.transform.Find("Result").GetComponent<Text>().text = "999";
            monsterStats.transform.Find("Result").GetComponent<Text>().text = "";
            playerStats.transform.Find("Result").GetComponent<Text>().color = Color.red;

        }
    }
    public void HealFun(int who)
    {
        if (who == 1)
        {
            playerStats.transform.Find("Action").GetComponent<Image>().sprite = HealAction;
            monsterStats.transform.Find("Action").GetComponent<Image>().sprite = NoAction;
            playerStats.transform.Find("Turn").GetComponent<Image>().color = Color.red;
            monsterStats.transform.Find("Turn").GetComponent<Image>().color = Color.green;
            monsterStats.transform.Find("Result").GetComponent<Text>().text = "";
            playerStats.transform.Find("Result").GetComponent<Text>().text = "999";
            playerStats.transform.Find("Result").GetComponent<Text>().color = Color.green;

        }
        else
        {
            monsterStats.transform.Find("Action").GetComponent<Image>().sprite = HealAction;
            playerStats.transform.Find("Action").GetComponent<Image>().sprite = NoAction;
            playerStats.transform.Find("Turn").GetComponent<Image>().color = Color.green;
            monsterStats.transform.Find("Turn").GetComponent<Image>().color = Color.red;
            playerStats.transform.Find("Result").GetComponent<Text>().text = "";
            monsterStats.transform.Find("Result").GetComponent<Text>().text = "999";
            monsterStats.transform.Find("Result").GetComponent<Text>().color = Color.green;
        }
    }
}
