using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sakas :  IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public float vitesse{get;set;}

    public Sakas ()
    {
            vie = 80;
            moral = 55;
            armure = 70;
            degat = 40;
            vitesse = 3.5f;

    }

}
