using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mélophore : IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public float vitesse{get;set;}

    public Mélophore()
    {
            vie = 160;
            moral = 65;
            armure = 95;
            degat = 31;
            vitesse = 1.8f;

    }

    

}
