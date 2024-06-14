using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalisteRomaine :  IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
   
    public float vitesse{get;set;}
    public int degatMelee { get; set; }
    public int degatDistance { get; set; }


    public BalisteRomaine ()
    {
            vie = 40;
            moral = 40;
            armure = 40;
            degatMelee = 35;
            degatDistance = 0;
            vitesse = 1;
    }
}
