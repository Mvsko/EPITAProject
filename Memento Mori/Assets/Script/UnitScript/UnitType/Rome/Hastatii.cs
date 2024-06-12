using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hastati :  IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public float vitesse{get;set;}


    public Hastati ()
    {
            vie = 160;
            moral = 40;
            armure = 60;
            degat = 28;
            vitesse = 2.2f;
            
    }

}
