﻿using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using System;
namespace Professor.Class
{
    public class CharacterOBJ
    {
        public String Name { get; set; }
        public float Gold { get; set; }
        public float Health { get; set; }
        public float MaxHealth { get; set; }
        public float Awareness { get; set; }
        public float MeleeAtk { get; set; }
        public float MeleeDef { get; set; }
        public float FireAtk { get; set; }
        public float FireDef { get; set; }
        public float IceAtk { get; set; }
        public float IceDef { get; set; }
        public float Heal { get; set; }
        public float Respawn { get; set; }
        public String Enemy { get; set; }
        public float EXP { get; set; }
        public Vector3 position { get; set; }
        public string PreFab { get; set; }

        

        public CharacterOBJ()
        {
            this.Name = "Professor Gomez";
            this.Gold = 0;
            this.Health = 150;
            this.MaxHealth = 150;
            this.Awareness = 10;
            this.MeleeAtk = 25;
            this.MeleeDef = 3;
            this.FireAtk = 5;
            this.FireDef = 3;
            this.IceAtk = 5;
            this.IceDef = 3;
            this.Heal = 4;
            this.Respawn = 100;
            this.Enemy = "";
            this.EXP = 0;
            this.position = Vector3.zero;
            this.PreFab = "Player";
        }

        public CharacterOBJ(int flag)
        {
            if (flag == 1)
            {
                this.Name = "";
                this.Gold = 0;
                this.Health = 200;
                this.MaxHealth = 200;
                this.Awareness = 10;
                this.MeleeAtk = 10;
                this.MeleeDef = 5;
                this.FireAtk = 2;
                this.FireDef = 1;
                this.IceAtk = 2;
                this.IceDef = 1;
                this.Heal = 4;
                this.Respawn = 50;
                this.EXP = 200;
                this.position = Vector3.zero;
                this.PreFab = "Wargbeast";
            }
            else if (flag == 2)
            {
                this.Name = "";
                this.Gold = 0;
                this.Health = 150;
                this.MaxHealth = 150;
                this.Awareness = 10;
                this.MeleeAtk = 8;
                this.MeleeDef = 3;
                this.FireAtk = 2;
                this.FireDef = 1;
                this.IceAtk = 10;
                this.IceDef = 5;
                this.Heal = 4;
                this.Respawn = 250;
                this.EXP = 150;
                this.position = Vector3.zero;
                this.PreFab = "Ghost";
            }
            else if (flag == 3)
            {
                this.Name = "";
                this.Gold = 0;
                this.Health = 180;
                this.MaxHealth = 180;
                this.Awareness = 10;
                this.MeleeAtk = 3;
                this.MeleeDef = 3;
                this.FireAtk = 12;
                this.FireDef = 6;
                this.IceAtk = 0;
                this.IceDef = 1;
                this.Heal = 4;
                this.Respawn = 250;
                this.EXP = 250;
                this.position = Vector3.zero;
                this.PreFab = "RedLizard";
            }
            else if (flag == 4)
            {
                this.Name = "";
                this.Gold = 0;
                this.Health = 250;
                this.MaxHealth = 250;
                this.Awareness = 10;
                this.MeleeAtk = 12;
                this.MeleeDef = 5;
                this.FireAtk = 0;
                this.FireDef = 2;
                this.IceAtk = 0;
                this.IceDef = 2;
                this.Heal = 4;
                this.Respawn = 300;
                this.EXP = 300;
                this.position = Vector3.zero;
                this.PreFab = "GreenLizard";
            }
            else if (flag == 5)
            {
                this.Name = "";
                this.Gold = 0;
                this.Health = 300;
                this.MaxHealth = 300;
                this.Awareness = 15;
                this.MeleeAtk = 12;
                this.MeleeDef = 5;
                this.FireAtk = 12;
                this.FireDef = 5;
                this.IceAtk = 12;
                this.IceDef = 5;
                this.Heal = 4;
                this.Respawn = 350;
                this.EXP = 350;
                this.position = Vector3.zero;
                this.PreFab = "GoldLizard";
            }
            else if (flag == 6)
            {
                this.Name = "";
                this.Gold = 0;
                this.Health = 250;
                this.MaxHealth = 250;
                this.Awareness = 15;
                this.MeleeAtk = 12;
                this.MeleeDef = 5;
                this.FireAtk = 1;
                this.FireDef = 5;
                this.IceAtk = 3;
                this.IceDef = 6;
                this.Heal = 4;
                this.Respawn = 300;
                this.EXP = 300;
                this.position = Vector3.zero;
                this.PreFab = "WhiteWerewolf";
            }
            else if (flag == 7)
            {
                this.Name = "";
                this.Gold = 0;
                this.Health = 250;
                this.MaxHealth = 250;
                this.Awareness = 15;
                this.MeleeAtk = 12;
                this.MeleeDef = 5;
                this.FireAtk = 1;
                this.FireDef = 5;
                this.IceAtk = 3;
                this.IceDef = 6;
                this.Heal = 4;
                this.Respawn = 300;
                this.EXP = 300;
                this.position = Vector3.zero;
                this.PreFab = "BlueWerewolf";
            }
            else if (flag == 8)
            {
                this.Name = "";
                this.Gold = 0;
                this.Health = 250;
                this.MaxHealth = 250;
                this.Awareness = 15;
                this.MeleeAtk = 12;
                this.MeleeDef = 5;
                this.FireAtk = 1;
                this.FireDef = 5;
                this.IceAtk = 3;
                this.IceDef = 6;
                this.Heal = 4;
                this.Respawn = 300;
                this.EXP = 300;
                this.position = Vector3.zero;
                this.PreFab = "WhiteDragon";
            }
            else if (flag == 9)
            {
                this.Name = "";
                this.Gold = 0;
                this.Health = 250;
                this.MaxHealth = 250;
                this.Awareness = 15;
                this.MeleeAtk = 12;
                this.MeleeDef = 5;
                this.FireAtk = 1;
                this.FireDef = 5;
                this.IceAtk = 3;
                this.IceDef = 6;
                this.Heal = 4;
                this.Respawn = 300;
                this.EXP = 300;
                this.position = Vector3.zero;
                this.PreFab = "RedDragon";
            }
            else if (flag == 10)
            {
                this.Name = "";
                this.Gold = 0;
                this.Health = 250;
                this.MaxHealth = 250;
                this.Awareness = 15;
                this.MeleeAtk = 12;
                this.MeleeDef = 5;
                this.FireAtk = 1;
                this.FireDef = 5;
                this.IceAtk = 3;
                this.IceDef = 6;
                this.Heal = 4;
                this.Respawn = 300;
                this.EXP = 300;
                this.position = Vector3.zero;
                this.PreFab = "GoldWargbeast";
            }
            else if (flag == 11)
            {
                this.Name = "";
                this.Gold = 0;
                this.Health = 250;
                this.MaxHealth = 250;
                this.Awareness = 15;
                this.MeleeAtk = 12;
                this.MeleeDef = 5;
                this.FireAtk = 1;
                this.FireDef = 5;
                this.IceAtk = 3;
                this.IceDef = 6;
                this.Heal = 4;
                this.Respawn = 300;
                this.EXP = 300;
                this.position = Vector3.zero;
                this.PreFab = "FantasyArcher_02A";
            }
        }
    }
}