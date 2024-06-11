using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalisteRomaine :  IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public int vitesse{get;set;}

    public BalisteRomaine ()
    {
            vie = 40;
            moral = 40;
            armure = 40;
            degat = 35;
            vitesse = 2;
    }
}
