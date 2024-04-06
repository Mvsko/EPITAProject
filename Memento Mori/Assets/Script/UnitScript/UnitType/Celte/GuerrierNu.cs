using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuerrierNu :  IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public int vitesse{get;set;}
    public string arme{get;}

    public string description{get;set;}

    public GuerrierNu ()
    {
            vie = 60;
            moral = 30;
            armure = 30;
            degat = 30;
            vitesse = 25;
            arme = "glaive";
            description = "Ce sont les soldats lourdement équipés des Romains. Ces régiments étaient composés de vétérans, ils forment une force aguerri et impressionnante.";
    }
    public void defendre(int dommage, string typeWeapon)
    {

    }

    public void attack()
    {

    }

}
