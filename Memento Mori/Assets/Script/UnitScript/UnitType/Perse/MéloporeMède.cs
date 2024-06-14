using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeloporeMede : IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public float vitesse{get;set;}
    public int degatMelee { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int degatDistance { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float attackingRangeDistance { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public MeloporeMede()
    {
            vie = 60;
            moral = 55;
            armure = 70;
            degat = 25;
            vitesse = 3;

    }

}
