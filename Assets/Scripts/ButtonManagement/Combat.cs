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
        monsterStats.transform.Find("HealResult").GetComponent<Text>().text = "";
        playerStats.transform.Find("HealResult").GetComponent<Text>().text = "";

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
            float Patk = DataManger.playerobj.MeleeAtk;
            MonsterScript mscript = (MonsterScript)GameObject.Find(DataManger.playerobj.Enemy).GetComponent("MonsterScript");
            float Mdef = mscript.Monsterobj.MeleeDef;
            float damage = 0;
            if ((Patk-Mdef)*2>0)
            {
                damage = (Patk - Mdef) * 2;
            }
            mscript.Monsterobj.Health -= damage;
            playerStats.transform.Find("Action").GetComponent<Image>().sprite = MeleeAction;
            playerStats.transform.Find("ActionLabel").GetComponent<Text>().text = "Melee Attack";
            monsterStats.transform.Find("Result").GetComponent<Text>().text = damage.ToString();
            playerStats.transform.Find("HealResult").GetComponent<Text>().text = "";
            monsterStats.transform.Find("Result").GetComponent<Text>().color = Color.red;
            Enemyturn();
        }
        else
        {
            float Pdef = DataManger.playerobj.MeleeDef;
            MonsterScript mscript = (MonsterScript)GameObject.Find(DataManger.playerobj.Enemy).GetComponent("MonsterScript");
            float Matk = mscript.Monsterobj.MeleeAtk;
            float damage = 0;
            if ((Matk - Pdef) * 2 > 0)
            {
                damage = (Matk - Pdef) * 2;
            }
            DataManger.playerobj.Health -= damage;
            monsterStats.transform.Find("Action").GetComponent<Image>().sprite = MeleeAction;
            monsterStats.transform.Find("ActionLabel").GetComponent<Text>().text = "Melee Attack";
            playerStats.transform.Find("Result").GetComponent<Text>().text = damage.ToString();
            monsterStats.transform.Find("HealResult").GetComponent<Text>().text = "";
            playerStats.transform.Find("Result").GetComponent<Text>().color = Color.red;
        }
    }
    public void FireFun(int who)
    {
        if (who == 1)
        {
            float Patk = DataManger.playerobj.FireAtk;
            MonsterScript mscript = (MonsterScript)GameObject.Find(DataManger.playerobj.Enemy).GetComponent("MonsterScript");
            float Mdef = mscript.Monsterobj.FireDef;
            float damage = 0;
            if ((Patk - Mdef) * 2 > 0)
            {
                damage = (Patk - Mdef) * 2;
            }
            mscript.Monsterobj.Health -= damage;
            playerStats.transform.Find("Action").GetComponent<Image>().sprite = FireAction;
            playerStats.transform.Find("ActionLabel").GetComponent<Text>().text = "Fire Attack";
            monsterStats.transform.Find("Result").GetComponent<Text>().text = damage.ToString();
            playerStats.transform.Find("HealResult").GetComponent<Text>().text = "";
            monsterStats.transform.Find("Result").GetComponent<Text>().color = Color.red;
            Enemyturn();
        }
        else
        {
            float Pdef = DataManger.playerobj.FireDef;
            MonsterScript mscript = (MonsterScript)GameObject.Find(DataManger.playerobj.Enemy).GetComponent("MonsterScript");
            float Matk = mscript.Monsterobj.FireAtk;
            float damage = 0;
            if ((Matk - Pdef) * 2 > 0)
            {
                damage = (Matk - Pdef) * 2;
            }
            DataManger.playerobj.Health -= damage;
            monsterStats.transform.Find("Action").GetComponent<Image>().sprite = FireAction;
            monsterStats.transform.Find("ActionLabel").GetComponent<Text>().text = "Fire Attack";
            playerStats.transform.Find("Result").GetComponent<Text>().text = damage.ToString();
            monsterStats.transform.Find("HealResult").GetComponent<Text>().text = "";
            playerStats.transform.Find("Result").GetComponent<Text>().color = Color.red;
        }
    }
    public void IceFun(int who)
    {
        if (who == 1)
        {
            float Patk = DataManger.playerobj.IceAtk;
            MonsterScript mscript = (MonsterScript)GameObject.Find(DataManger.playerobj.Enemy).GetComponent("MonsterScript");
            float Mdef = mscript.Monsterobj.IceDef;
            float damage = 0;
            if ((Patk - Mdef) * 2 > 0)
            {
                damage = (Patk - Mdef) * 2;
            }
            mscript.Monsterobj.Health -= damage;
            playerStats.transform.Find("Action").GetComponent<Image>().sprite = IceAction;
            playerStats.transform.Find("ActionLabel").GetComponent<Text>().text = "Ice Attack";
            monsterStats.transform.Find("Result").GetComponent<Text>().text = damage.ToString();
            playerStats.transform.Find("HealResult").GetComponent<Text>().text = "";
            monsterStats.transform.Find("Result").GetComponent<Text>().color = Color.red;
            Enemyturn();
        }
        else
        {
            float Pdef = DataManger.playerobj.IceDef;
            MonsterScript mscript = (MonsterScript)GameObject.Find(DataManger.playerobj.Enemy).GetComponent("MonsterScript");
            float Matk = mscript.Monsterobj.IceAtk;
            float damage = 0;
            if ((Matk - Pdef) * 2 > 0)
            {
                damage = (Matk - Pdef) * 2;
            }
            DataManger.playerobj.Health -= damage;
            monsterStats.transform.Find("Action").GetComponent<Image>().sprite = IceAction;
            monsterStats.transform.Find("ActionLabel").GetComponent<Text>().text = "Ice Attack";
            playerStats.transform.Find("Result").GetComponent<Text>().text = damage.ToString();
            monsterStats.transform.Find("HealResult").GetComponent<Text>().text = "";
            playerStats.transform.Find("Result").GetComponent<Text>().color = Color.red;
        }
    }
    public void HealFun(int who)
    {
        if (who == 1)
        {
            float MaxHealth = DataManger.playerobj.MaxHealth;
            float Health = DataManger.playerobj.Health;
            float Pheal = DataManger.playerobj.Heal;
            if (MaxHealth > Health)
            {
                float increase = Pheal * 10;
                if (MaxHealth < Health+increase)
                {
                    increase = MaxHealth - Health;
                }
                DataManger.playerobj.Health += increase;
                playerStats.transform.Find("Action").GetComponent<Image>().sprite = HealAction;
                playerStats.transform.Find("ActionLabel").GetComponent<Text>().text = "Heal";
                monsterStats.transform.Find("Result").GetComponent<Text>().text = "";
                playerStats.transform.Find("HealResult").GetComponent<Text>().text = increase.ToString();
                playerStats.transform.Find("HealResult").GetComponent<Text>().color = Color.green;
                Enemyturn();
            }

        }
        else
        {
            MonsterScript mscript = (MonsterScript)GameObject.Find(DataManger.playerobj.Enemy).GetComponent("MonsterScript");
            float Mdef = mscript.Monsterobj.IceDef;
            float MaxHealth = mscript.Monsterobj.MaxHealth;
            float Health = mscript.Monsterobj.Health;
            float Pheal = mscript.Monsterobj.Heal;
            if (MaxHealth > Health)
            {
                float increase = Pheal * 10;
                if (MaxHealth < Health + increase)
                {
                    increase = MaxHealth - Health;
                }
                mscript.Monsterobj.Health += increase;
                monsterStats.transform.Find("Action").GetComponent<Image>().sprite = HealAction;
                monsterStats.transform.Find("ActionLabel").GetComponent<Text>().text = "Heal";
                playerStats.transform.Find("Result").GetComponent<Text>().text = "";
                monsterStats.transform.Find("HealResult").GetComponent<Text>().text = increase.ToString();
                monsterStats.transform.Find("HealResult").GetComponent<Text>().color = Color.green;
            }
        }
    }

    public void Enemyturn()
    {
        MonsterScript mscript = (MonsterScript)GameObject.Find(DataManger.playerobj.Enemy).GetComponent("MonsterScript");
        float mdif = mscript.Monsterobj.MeleeAtk - DataManger.playerobj.MeleeDef;
        float fdif = mscript.Monsterobj.FireAtk - DataManger.playerobj.FireDef;
        float idif = mscript.Monsterobj.IceAtk - DataManger.playerobj.IceDef;
        if (mdif >= fdif)
        {
            if (mdif >= idif)
            {
                MeleeFun(0);
            }
            else
            {
                IceFun(0);
            }
        }
        else
        {
            if (fdif >= idif)
            {
                FireFun(0);
            }
            else
            {
                IceFun(0);
            }
        }
        DataManger.SetupCombat(GameObject.Find("CombatPanel"), GameObject.Find("Player"), mscript.Monsterobj, GameObject.Find(DataManger.playerobj.Enemy).GetComponent<Animator>(), GameObject.Find(DataManger.playerobj.Enemy));
    }
}
