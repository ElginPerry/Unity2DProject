using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using System;
namespace Professor.Class
{
    public class ItemObj
    {
        public String Name { get; set; }
        public String Type { get; set; }
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
        public float EXP { get; set; }
        public string PreFabName { get; set; }
        public Sprite Sprite { get; set; }
        public float Duration { get; set; }

        public ItemObj()
        {
            this.Name = "";
            this.Type = "";
            this.Gold = 0;
            this.Health = 0;
            this.MaxHealth = 0;
            this.Awareness = 0;
            this.MeleeAtk = 0;
            this.MeleeDef = 0;
            this.FireAtk = 0;
            this.FireDef = 0;
            this.IceAtk = 0;
            this.IceDef = 0;
            this.Heal = 0;
            this.EXP = 0;
            this.PreFabName = "";
            this.Sprite = null;
            this.Duration = 0;
        }        
    }
}