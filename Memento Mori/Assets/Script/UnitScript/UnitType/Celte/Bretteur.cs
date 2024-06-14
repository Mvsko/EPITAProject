using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bretteur : IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degatMelee { get; set; }
    public int degatDistance { get; set; }
    public float vitesse{get;set;}

    public Bretteur ()
    {
            vie = 160;
            moral = 45;
            armure = 45;
            degatMelee = 27;
            degatDistance = 0;
            vitesse = 1.5f;

    }

}
