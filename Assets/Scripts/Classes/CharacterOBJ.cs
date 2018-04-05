using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using System;
namespace Professor.Class
{
    public class CharacterOBJ
    {
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

        

        public CharacterOBJ()
        {
            this.Gold = 0;
            this.Health = 150;
            this.MaxHealth = 150;
            this.Awareness = 10;
            this.MeleeAtk = 10;
            this.MeleeDef = 5;
            this.FireAtk = 5;
            this.FireDef = 3;
            this.IceAtk = 5;
            this.IceDef = 3;
            this.Heal = 4;
            this.Respawn = 1;
            this.Enemy = "";
        }

        public CharacterOBJ(int flag)
        {
            if (flag == 1)
            {
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
                this.Respawn = 10;
            }
            else if (flag == 2)
            {
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
                this.Respawn = 5;
            }

        }
    }
}