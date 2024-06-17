using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelophoreMede : IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public float vitesse{get;set;}
    public int degatMelee { get; set; }
    public int degatDistance { get; set; }
    public float attackingRangeDistance { get; set; }

    public MelophoreMede()
    {
            vie = 60;
            moral = 55;
            armure = 70;
            degat = 25;
            vitesse = 3;
        degatMelee = 25;
        degatDistance = 0;
        attackingRangeDistance = 0;


    }

}
