using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherPerse :  IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public float vitesse{get;set;}
    public int degatMelee { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int degatDistance { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float attackingRangeDistance { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public ArcherPerse()
    {
            vie = 120;
            moral = 25;
            armure = 25;
            degat = 23;
            vitesse = 2.5f;

    }
}
