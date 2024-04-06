using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equites :  IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public int vitesse{get;set;}
    public string arme{get;set;}
    public string description{get;set;}

    public Equites ()
    {
            vie = 100;
            moral = 40;
            armure = 40;
            degat = 40;
            vitesse = 20;
            arme = "glaive";
            description = "";
    }
    public void defendre(int dommage, string typeWeapon)
    {

    }

    public void attack()
    {

    }

}
