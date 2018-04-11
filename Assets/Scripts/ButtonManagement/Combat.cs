using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Professor.Class;

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

    float hldPlayerHeal = 0;
    float hldMonsterDamage = 0;

    ItemObj bonus;
    public void MeleeClicked()
    {
        bonus = DataManger.GearBonus();
        MeleeFun(1);
    }
    public void FireClicked()
    {
        bonus = DataManger.GearBonus();
        FireFun(1);
    }
    public void IceClicked()
    {
        bonus = DataManger.GearBonus();
        IceFun(1);
    }
    public void HealClicked()
    {
        bonus = DataManger.GearBonus();
        HealFun(1);
    }
    public void EscapeClicked()
    {
        bonus = DataManger.GearBonus();
        Resume();
    }

    public void Resume()
    {
        PlayerMove script = (PlayerMove)GameObject.Find("Player").GetComponent("PlayerMove");
        script.moveEnabled = true;
        MonsterScript mscript = (MonsterScript)GameObject.Find(DataManger.playerobj.Enemy).GetComponent("MonsterScript");
        mscript.moveEnabled = true;
        Animator Panim = GameObject.Find("Player").GetComponent<Animator>();
        Animator Manim = GameObject.Find(DataManger.playerobj.Enemy).GetComponent<Animator>();
        Panim.enabled = true;
        Manim.enabled = true;

        playerStats.transform.Find("Action").GetComponent<Image>().sprite = NoAction;
        monsterStats.transform.Find("Action").GetComponent<Image>().sprite = NoAction;
        monsterStats.transform.Find("Result").GetComponent<Text>().text = "";
        playerStats.transform.Find("Result").GetComponent<Text>().text = "";
        monsterStats.transform.Find("HealResult").GetComponent<Text>().text = "";
        playerStats.transform.Find("HealResult").GetComponent<Text>().text = "";
        monsterStats.transform.Find("MonsterDamage").GetComponent<Text>().text = "";
        playerStats.transform.Find("PlayerDamage").GetComponent<Text>().text = "";

        GameObject cp = GameObject.Find("CombatPanel");
        if (cp != null)
        {
            cp.SetActive(false);
        }

    }

    public void MeleeFun(int who)
    {
        if (who == 1)
        {            
            float Patk = DataManger.playerobj.MeleeAtk + bonus.MeleeAtk;
            MonsterScript mscript = (MonsterScript)GameObject.Find(DataManger.playerobj.Enemy).GetComponent("MonsterScript");
            float Mdef = mscript.Monsterobj.MeleeDef;
            float damage = 0;
            if ((Patk-Mdef)*2>0)
            {
                damage = Mathf.Round(((Patk - Mdef) * 2) * Random.Range(.7f, 1.2f));
            }
            mscript.Monsterobj.Health -= damage;
            playerStats.transform.Find("Action").GetComponent<Image>().sprite = MeleeAction;
            playerStats.transform.Find("ActionLabel").GetComponent<Text>().text = "Melee Attack";
            playerStats.transform.Find("Result").GetComponent<Text>().text = damage.ToString();
            playerStats.transform.Find("HealResult").GetComponent<Text>().text = "";
            playerStats.transform.Find("Result").GetComponent<Text>().color = Color.red;
            hldMonsterDamage = damage;
            hldPlayerHeal = 0;
            Enemyturn();
        }
        else
        {
            float Pdef = DataManger.playerobj.MeleeDef + bonus.MeleeDef;
            MonsterScript mscript = (MonsterScript)GameObject.Find(DataManger.playerobj.Enemy).GetComponent("MonsterScript");
            float Matk = mscript.Monsterobj.MeleeAtk;
            float damage = 0;
            if ((Matk - Pdef) * 2 > 0)
            {
                damage = Mathf.Round(((Matk - Pdef) * 2) * Random.Range(.7f, 1.2f));
            }
            DataManger.playerobj.Health -= damage;
            monsterStats.transform.Find("Action").GetComponent<Image>().sprite = MeleeAction;
            monsterStats.transform.Find("ActionLabel").GetComponent<Text>().text = "Melee Attack";
            monsterStats.transform.Find("Result").GetComponent<Text>().text = damage.ToString();
            monsterStats.transform.Find("HealResult").GetComponent<Text>().text = "";
            monsterStats.transform.Find("Result").GetComponent<Text>().color = Color.red;
            monsterStats.transform.Find("MonsterDamage").GetComponent<Text>().text = hldMonsterDamage.ToString();
            monsterStats.transform.Find("MonsterDamage").GetComponent<Text>().color = Color.red;
            if (damage - hldPlayerHeal > 0)
            {
                playerStats.transform.Find("PlayerDamage").GetComponent<Text>().text = (damage - hldPlayerHeal).ToString();
                playerStats.transform.Find("PlayerDamage").GetComponent<Text>().color = Color.red;
            }
            else
            {
                playerStats.transform.Find("PlayerDamage").GetComponent<Text>().text = (hldPlayerHeal - damage).ToString();
                playerStats.transform.Find("PlayerDamage").GetComponent<Text>().color = Color.green;
            }

        }
    }
    public void FireFun(int who)
    {
        if (who == 1)
        {
            float Patk = DataManger.playerobj.FireAtk + bonus.FireAtk;
            MonsterScript mscript = (MonsterScript)GameObject.Find(DataManger.playerobj.Enemy).GetComponent("MonsterScript");
            float Mdef = mscript.Monsterobj.FireDef;
            float damage = 0;
            if ((Patk - Mdef) * 2 > 0)
            {
                damage = Mathf.Round(((Patk - Mdef) * 2) *Random.Range(.7f, 1.2f));
            }
            mscript.Monsterobj.Health -= damage;
            playerStats.transform.Find("Action").GetComponent<Image>().sprite = FireAction;
            playerStats.transform.Find("ActionLabel").GetComponent<Text>().text = "Fire Attack";
            playerStats.transform.Find("Result").GetComponent<Text>().text = damage.ToString();
            playerStats.transform.Find("HealResult").GetComponent<Text>().text = "";
            playerStats.transform.Find("Result").GetComponent<Text>().color = Color.red;
            hldMonsterDamage = damage;
            hldPlayerHeal = 0;
            Enemyturn();
        }
        else
        {
            float Pdef = DataManger.playerobj.FireDef + bonus.FireDef;
            MonsterScript mscript = (MonsterScript)GameObject.Find(DataManger.playerobj.Enemy).GetComponent("MonsterScript");
            float Matk = mscript.Monsterobj.FireAtk;
            float damage = 0;
            if ((Matk - Pdef) * 2 > 0)
            {
                damage = Mathf.Round(((Matk - Pdef) * 2) *Random.Range(.7f, 1.2f));
            }
            DataManger.playerobj.Health -= damage;
            monsterStats.transform.Find("Action").GetComponent<Image>().sprite = FireAction;
            monsterStats.transform.Find("ActionLabel").GetComponent<Text>().text = "Fire Attack";
            monsterStats.transform.Find("Result").GetComponent<Text>().text = damage.ToString();
            monsterStats.transform.Find("HealResult").GetComponent<Text>().text = "";
            monsterStats.transform.Find("Result").GetComponent<Text>().color = Color.red;
            monsterStats.transform.Find("MonsterDamage").GetComponent<Text>().text = hldMonsterDamage.ToString();
            monsterStats.transform.Find("MonsterDamage").GetComponent<Text>().color = Color.red;
            if (damage - hldPlayerHeal > 0)
            {
                playerStats.transform.Find("PlayerDamage").GetComponent<Text>().text = (damage - hldPlayerHeal).ToString();
                playerStats.transform.Find("PlayerDamage").GetComponent<Text>().color = Color.red;
            }
            else
            {
                playerStats.transform.Find("PlayerDamage").GetComponent<Text>().text = (hldPlayerHeal - damage).ToString();
                playerStats.transform.Find("PlayerDamage").GetComponent<Text>().color = Color.green;
            }


        }
    }
    public void IceFun(int who)
    {
        if (who == 1)
        {
            float Patk = DataManger.playerobj.IceAtk + bonus.IceAtk;
            MonsterScript mscript = (MonsterScript)GameObject.Find(DataManger.playerobj.Enemy).GetComponent("MonsterScript");
            float Mdef = mscript.Monsterobj.IceDef;
            float damage = 0;
            if ((Patk - Mdef) * 2 > 0)
            {
                damage = Mathf.Round(((Patk - Mdef) * 2) *Random.Range(.7f, 1.2f));
            }
            mscript.Monsterobj.Health -= damage;
            playerStats.transform.Find("Action").GetComponent<Image>().sprite = IceAction;
            playerStats.transform.Find("ActionLabel").GetComponent<Text>().text = "Ice Attack";
            playerStats.transform.Find("Result").GetComponent<Text>().text = damage.ToString();
            playerStats.transform.Find("HealResult").GetComponent<Text>().text = "";
            playerStats.transform.Find("Result").GetComponent<Text>().color = Color.red;
            hldMonsterDamage = damage;
            hldPlayerHeal = 0;
            Enemyturn();
        }
        else
        {
            float Pdef = DataManger.playerobj.IceDef + bonus.IceDef;
            MonsterScript mscript = (MonsterScript)GameObject.Find(DataManger.playerobj.Enemy).GetComponent("MonsterScript");
            float Matk = mscript.Monsterobj.IceAtk;
            float damage = 0;
            if ((Matk - Pdef) * 2 > 0)
            {
                damage = Mathf.Round(((Matk - Pdef) * 2) * Random.Range(.7f,1.2f));
            }
            DataManger.playerobj.Health -= damage;
            monsterStats.transform.Find("Action").GetComponent<Image>().sprite = IceAction;
            monsterStats.transform.Find("ActionLabel").GetComponent<Text>().text = "Ice Attack";
            monsterStats.transform.Find("Result").GetComponent<Text>().text = damage.ToString();
            monsterStats.transform.Find("HealResult").GetComponent<Text>().text = "";
            monsterStats.transform.Find("Result").GetComponent<Text>().color = Color.red;

            monsterStats.transform.Find("MonsterDamage").GetComponent<Text>().text = hldMonsterDamage.ToString();
            monsterStats.transform.Find("MonsterDamage").GetComponent<Text>().color = Color.red;
            if (damage - hldPlayerHeal > 0)
            {
                playerStats.transform.Find("PlayerDamage").GetComponent<Text>().text = (damage - hldPlayerHeal).ToString();
                playerStats.transform.Find("PlayerDamage").GetComponent<Text>().color = Color.red;
            }
            else
            {
                playerStats.transform.Find("PlayerDamage").GetComponent<Text>().text = (hldPlayerHeal - damage).ToString();
                playerStats.transform.Find("PlayerDamage").GetComponent<Text>().color = Color.green;
            }


        }
    }
    public void HealFun(int who)
    {
        if (who == 1)
        {
            float MaxHealth = DataManger.playerobj.MaxHealth;
            float Health = DataManger.playerobj.Health;
            float Pheal = DataManger.playerobj.Heal + bonus.Heal;
            if (MaxHealth > Health)
            {
                float increase = Pheal * 10;
                if (MaxHealth < Health+increase)
                {
                    increase = MaxHealth - Health;
                }
                increase = Mathf.Round(increase);
                DataManger.playerobj.Health += increase;
                playerStats.transform.Find("Action").GetComponent<Image>().sprite = HealAction;
                playerStats.transform.Find("ActionLabel").GetComponent<Text>().text = "Heal";
                monsterStats.transform.Find("Result").GetComponent<Text>().text = "";
                playerStats.transform.Find("HealResult").GetComponent<Text>().text = increase.ToString();
                playerStats.transform.Find("HealResult").GetComponent<Text>().color = Color.green;
                hldMonsterDamage = 0;
                hldPlayerHeal = increase;
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
                playerStats.transform.Find("PlayerDamage").GetComponent<Text>().text = hldPlayerHeal.ToString();
                playerStats.transform.Find("PlayerDamage").GetComponent<Text>().color = Color.green;
                
                if (hldMonsterDamage - increase > 0)
                {
                    monsterStats.transform.Find("MonsterDamage").GetComponent<Text>().text = (hldMonsterDamage - increase).ToString();
                    monsterStats.transform.Find("MonsterDamage").GetComponent<Text>().color = Color.red;
                }
                else
                {
                    monsterStats.transform.Find("MonsterDamage").GetComponent<Text>().text = (increase - hldMonsterDamage).ToString();
                    monsterStats.transform.Find("MonsterDamage").GetComponent<Text>().color = Color.green;
                }
            }
        }
    }
    public void Enemyturn()
    {
        MonsterScript mscript = (MonsterScript)GameObject.Find(DataManger.playerobj.Enemy).GetComponent("MonsterScript");
        float mdif = mscript.Monsterobj.MeleeAtk - (DataManger.playerobj.MeleeDef + bonus.MeleeDef);
        float fdif = mscript.Monsterobj.FireAtk - (DataManger.playerobj.FireDef + bonus.FireDef);
        float idif = mscript.Monsterobj.IceAtk - (DataManger.playerobj.IceDef + bonus.IceDef);
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
