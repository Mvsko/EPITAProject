using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasseur :  IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degatMelee { get; set; }
    public int degatDistance { get; set; }
    public float vitesse{get;set;}
    public Chasseur()
    {
            vie = 120;
            moral = 40;
            armure = 10;
            degatMelee = 25;
            degatDistance = 0;
            vitesse = 2.5f;

    }

}
