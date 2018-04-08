using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using System;
namespace Professor.Class
{
    public class LootInfo
    {
        public String Name { get; set; }
        public float EXP { get; set; }

        public LootInfo()
        {
            this.Name = "";
            this.EXP = 0;
        }
    }
}