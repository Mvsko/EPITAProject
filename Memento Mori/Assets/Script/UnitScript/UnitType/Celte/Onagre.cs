using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onagre :  IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public float vitesse{get;set;}

    public Onagre ()
    {
            vie = 40;
            moral = 40;
            armure = 10;
            degat = 35;
            vitesse = 1;
}

}
