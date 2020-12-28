using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Enemy : MonoBehaviour
{    
    [SerializeField] int layer;    
    [SerializeField] int pointWorth;

    public Enemy(int layer)
    {                        
        this.Layer = layer;        
    }

    public int Layer { get => layer; set => layer = value; }
    public int PointWorth { get => pointWorth; set => pointWorth = value; }
}
