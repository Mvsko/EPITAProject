using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trimarcisia :  IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degatMelee { get; set; }
    public int degatDistance { get; set; }
    public float vitesse{get;set;}
    public float attackingRangeDistance {get; set; }
    public Trimarcisia ()
    {
            vie = 80;
            moral = 55;
            armure = 60;
            degatMelee = 42;
            degatDistance = 0;
            vitesse = 3.5f;
            attackingRangeDistance = 0;
}


}
