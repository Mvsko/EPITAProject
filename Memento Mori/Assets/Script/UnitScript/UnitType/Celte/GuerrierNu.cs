using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuerrierNu :  IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degatMelee { get; set; }
    public int degatDistance { get; set; }
    public float vitesse{get;set;}
    public float attackingRangeDistance {get; set; }
    public GuerrierNu ()
    {
            vie = 160;
            moral = 40;
            armure = 10;
            degatMelee = 34;
            degatDistance = 0;
            vitesse = 2;
            attackingRangeDistance = 0;
}


}
