using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using System;
namespace Professor.Class
{
    public class RespawnObj
    {
        public String PreFabName { get; set; }
        public Vector3 position { get; set; }
        public float RespawnTime { get; set; }

        public RespawnObj()
        {
            this.PreFabName = "";
            this.position = Vector3.zero;
            this.RespawnTime = 0;
        }
    }
}