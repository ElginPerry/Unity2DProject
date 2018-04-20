using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using System;
namespace Professor.Class
{
    public class MovementObj
    {
        public float vSpeed { get; set; }
        public float hSpeed { get; set; }
        public bool ClickMove { get; set; }
        public GameObject combatTarget { get; set; }
        public MonsterScript monsterScript { get; set; }
        public CharacterOBJ combatMonster { get; set; }
        public MovementObj()
        {
            this.hSpeed = 0;
            this.vSpeed = 0;
            this.ClickMove = false;
        }
    }
}