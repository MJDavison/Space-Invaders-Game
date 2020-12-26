using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Enemy : MonoBehaviour
{    
    [SerializeField] int layer;    

    public Enemy(int layer)
    {                        
        this.Layer = layer;        
    }

    public int Layer { get => layer; set => layer = value; }
}
