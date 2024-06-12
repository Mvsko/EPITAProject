using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legat : IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public float vitesse{get;set;}
    public Legat ()
    {
            vie = 60;
            moral = 55;
            armure = 70;
            degat = 25;
            vitesse = 3;

    }

}
