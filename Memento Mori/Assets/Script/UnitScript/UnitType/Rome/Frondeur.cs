using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frondeur :  IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degatMelee { get; set; }
    public int degatDistance { get; set; }
    public float vitesse{get;set;}

    public Frondeur ()
    {
            vie = 120;
            moral = 25;
            armure = 25;
            degatMelee = 23;
            degatDistance = 0;
            vitesse = 2.5f;

    }
}
