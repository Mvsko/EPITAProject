using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equites :  IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
     public int degatMelee { get; set; }
    public int degatDistance { get; set; }
    public float vitesse{get;set;}

    public Equites ()
    {
            vie = 80;
            moral = 55;
            armure = 70;
            degatMelee = 40;
            degatDistance=0;
            vitesse = 3.5f;

    }

}
