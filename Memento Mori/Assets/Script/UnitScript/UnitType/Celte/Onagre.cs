using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onagre :  IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degatMelee { get; set; }
    public int degatDistance { get; set; }
    public float vitesse{get;set;}
    public float attackingRangeDistance {get;set;}
    public Onagre ()
    {
            vie = 40;
            moral = 40;
            armure = 10;
            degatMelee = 10;
            degatDistance = 35;
            vitesse = 1;
            attackingRangeDistance = 25f;
            
}

}
