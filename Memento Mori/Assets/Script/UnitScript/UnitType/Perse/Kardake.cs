using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kardake :  IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public float vitesse{get;set;}
    public int degatMelee { get; set; }
    public int degatDistance { get; set; }
    public float attackingRangeDistance { get; set; }

    public Kardake()
    {
            vie = 160;
            moral = 40;
            armure = 60;
            degat = 28;
            vitesse = 2.2f;

        degatMelee = 28;
        degatDistance = 0;
        attackingRangeDistance = 0;

    }

}
