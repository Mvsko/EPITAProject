using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasseur :  IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public float vitesse{get;set;}
    public Chasseur()
    {
            vie = 120;
            moral = 40;
            armure = 10;
            degat = 25;
            vitesse = 2.5f;

    }

}
