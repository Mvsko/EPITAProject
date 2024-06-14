using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legat : IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degatMelee { get; set; }
    public int degatDistance { get; set; }
    public float vitesse{get;set;}
    public float attackingRangeDistance {get; set; }
    public Legat ()
    {
            vie = 60;
            moral = 55;
            armure = 70;
            degatMelee = 25;
            degatDistance = 0;
            vitesse = 3;
            attackingRangeDistance = 0;
    }

}
