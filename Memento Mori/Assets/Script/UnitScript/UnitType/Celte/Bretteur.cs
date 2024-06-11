using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bretteur : IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public int vitesse{get;set;}

    public Bretteur ()
    {
            vie = 160;
            moral = 45;
            armure = 45;
            degat = 27;
            vitesse = 2;

    }

}
