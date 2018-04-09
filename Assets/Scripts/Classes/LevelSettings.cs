using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using System;
namespace Professor.Class
{
    public class LevelSettings
    {
        public String Name { get; set; }
        public int Level { get; set; }
        public int ExpRequired { get; set; }


        public LevelSettings()
        {
            this.Name = "";
            this.Level = 0;
            this.ExpRequired = 0;
        }
    }
}