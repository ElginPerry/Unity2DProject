using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using System;
namespace Professor.Class
{
    public class ItemObj
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
        public string Sprite { get; set; }

        public ItemObj()
        {
            this.Name = "Professor Gomez";
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
            this.Respawn = 100;
            this.Enemy = "";
            this.EXP = 0;
            this.position = Vector3.zero;
            this.Sprite = "";
        }        
    }
}