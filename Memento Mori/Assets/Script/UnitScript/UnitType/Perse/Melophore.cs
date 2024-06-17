using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melophore : IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public float vitesse{get;set;}
    public int degatMelee { get; set; }
    public int degatDistance { get; set; }
    public float attackingRangeDistance { get; set; }

    public Melophore()
    {
            vie = 160;
            moral = 65;
            armure = 95;
            degat = 31;
            vitesse = 1.8f;

        degatMelee = 31;
        degatDistance = 0;
        attackingRangeDistance = 0;

    }

    

}
