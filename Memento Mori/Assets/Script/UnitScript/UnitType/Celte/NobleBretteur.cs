using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NobleBretteur : IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degatMelee { get; set; }
    public int degatDistance { get; set; }
    public float vitesse{get;set;}

    public NobleBretteur ()
    {
            vie = 160;
            moral = 70;
            armure = 75;
            degatMelee = 34;
            degatDistance = 0;
            vitesse = 1.5f;
 }
 

}
