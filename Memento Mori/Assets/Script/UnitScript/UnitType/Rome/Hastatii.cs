using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hastati :  IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degatMelee { get; set; }
    public int degatDistance { get; set; }
    public float vitesse{get;set;}


    public Hastati ()
    {
            vie = 160;
            moral = 40;
            armure = 60;
            degatMelee = 28;
            degatDistance = 0;
            vitesse = 2.2f;
            
    }

}
