using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using System;
namespace Professor.Class
{
    public class PlayerOBJ
    {

        public float Health { get; set; }
        public float Credits { get; set; }
       

        public PlayerOBJ()
        {
            this.Credits = 0;
            this.Health = 0;
        }


    }
}