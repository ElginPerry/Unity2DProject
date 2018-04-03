using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using System;
namespace Professor.Class
{
    public class PlayerLevelOBJ
    {
        public float Level { get; set; }
        public float Awareness { get; set; }
        public float MeleeAtk { get; set; }
        public float MeleeDef { get; set; }
        public float FireAtk { get; set; }
        public float FireDef { get; set; }
        public float IceAtk { get; set; }
        public float IceDef { get; set; }
        public float Heal { get; set; }

        public PlayerLevelOBJ()
        {
            this.Level = 1;
            this.Awareness = 1;
            this.MeleeAtk = 1;
            this.MeleeDef = 1;
            this.FireAtk = 0;
            this.FireDef = 0;
            this.IceAtk = 0;
            this.IceDef = 0;
            this.Heal = 1;
        }
    }
}